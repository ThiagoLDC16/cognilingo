import { isAxiosError } from 'axios';

import { authApi } from '@/features/auth/api/auth-api';
import type {
  AuthTokensResponse,
  LoginPayload,
  RegisterPayload,
} from '@/features/auth/api/auth-api/types';
import { clearAuthSession, saveAuthSession, syncLoggedUser } from '@/features/auth/services/auth-session';
import { restoreAuthTokens } from '@/features/auth/services/auth-storage';
import { authStore } from '@/features/auth/store/auth-store';

async function applyAuthenticatedSession(request: Promise<AuthTokensResponse>) {
  const tokens = await request;

  await saveAuthSession(tokens);

  try {
    await syncLoggedUser();
  } catch (error) {
    if (isAxiosError(error) && error.response?.status === 401) {
      await clearAuthSession();
      throw error;
    }

    authStore.setUser(null);
  }
}

export async function bootstrapAuthSession() {
  authStore.setState({ isHydrating: true });

  try {
    const tokens = await restoreAuthTokens();

    if (!tokens) {
      authStore.setState({
        accessToken: null,
        refreshToken: null,
        user: null,
        status: 'unauthenticated',
        isHydrating: false,
      });
      return;
    }

    authStore.setTokens(tokens);

    try {
      await syncLoggedUser();
    } catch {
      authStore.setUser(null);
    }
  } finally {
    authStore.setState({ isHydrating: false });
  }
}

export async function signIn(payload: LoginPayload) {
  await applyAuthenticatedSession(authApi.login(payload));
}

export async function signUp(payload: RegisterPayload) {
  await applyAuthenticatedSession(authApi.register(payload));
}

export async function signOut() {
  await clearAuthSession();
}
