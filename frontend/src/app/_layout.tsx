import '@/i18n';
import '../global.css';

import { Slot, useRouter, useSegments } from 'expo-router';
import * as SplashScreen from 'expo-splash-screen';
import { useEffect } from 'react';

import { authApi } from '@/features/auth/api/auth-api';
import { authStore } from '@/features/auth/store/auth-store';
import { storage } from '@/shared/utils/storage';

SplashScreen.preventAutoHideAsync();

export default function RootLayout() {
  const isReady = authStore((state) => state.isReady);
  const user = authStore((state) => state.user);
  const segments = useSegments();
  const router = useRouter();

  // Load user from persistent storage on startup
  useEffect(() => {
    const restoreSession = async () => {
      try {
        const accessToken = await storage.getItem('accessToken');
        const refreshToken = await storage.getItem('refreshToken');

        if (accessToken && refreshToken) {
          authStore.getState().setTokens({ accessToken, refreshToken });
          try {
            // Fetch profile securely
            const loggedUser = await authApi.getLoggedUser();
            authStore.getState().setUser(loggedUser);
          } catch (e) {
            console.error('Failed to restore user session during initialization:', e);
            authStore.getState().logout();
          }
        }
      } catch (error) {
        console.error('Failed to restore session via storage', error);
      } finally {
        authStore.getState().setReady(true);
      }
    };

    restoreSession();
  }, []);

  // Secure routing rules
  useEffect(() => {
    if (!isReady) return;

    const inAuthGroup = segments[0] === '(auth)';
    const inOnboardingGroup = segments[0] === '(onboarding)';
    const isLoggedIn = !!user;
    const hasProfile = user?.hasProfile ?? false;

    if (!isLoggedIn && !inAuthGroup) {
      router.replace('/(auth)/login');
    } else if (isLoggedIn && inAuthGroup) {
      router.replace(hasProfile ? '/(app)/' : '/(onboarding)/setup');
    } else if (isLoggedIn && !hasProfile && !inOnboardingGroup) {
      router.replace('/(onboarding)/setup');
    } else if (isLoggedIn && hasProfile && inOnboardingGroup) {
      router.replace('/(app)/');
    }
  }, [user, isReady, segments, router]);

  // Dismiss splash screen post hydration
  useEffect(() => {
    if (isReady) {
      SplashScreen.hideAsync();
    }
  }, [isReady]);

  if (!isReady) {
    return null;
  }

  return <Slot />;
}
