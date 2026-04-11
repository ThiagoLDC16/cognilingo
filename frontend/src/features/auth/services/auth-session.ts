import axios, { isAxiosError } from 'axios';

import { authApi } from '@/features/auth/api/auth-api';
import type { AuthTokensResponse } from '@/features/auth/api/auth-api/types';
import { clearPersistedAuthTokens, persistAuthTokens } from '@/features/auth/services/auth-storage';
import { authStore } from '@/features/auth/store/auth-store';
import { env } from '@/shared/config/env';

const refreshClient = axios.create({
  baseURL: env.apiBaseUrl,
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

let refreshPromise: Promise<AuthTokensResponse | null> | null = null;

export async function saveAuthSession(tokens: AuthTokensResponse) {
  authStore.setTokens(tokens);
  await persistAuthTokens(tokens);
}

export async function clearAuthSession() {
  authStore.setTokens(null);
  authStore.setUser(null);
  await clearPersistedAuthTokens();
}

export async function refreshAuthSession() {
  const refreshToken = authStore.getState().refreshToken;

  if (!refreshToken) {
    await clearAuthSession();
    return null;
  }

  if (refreshPromise) {
    return refreshPromise;
  }

  refreshPromise = (async () => {
    try {
      const response = await refreshClient.post<AuthTokensResponse>('/api/auth/refresh', {
        refreshToken,
      });

      await saveAuthSession(response.data);
      return response.data;
    } catch {
      await clearAuthSession();
      return null;
    } finally {
      refreshPromise = null;
    }
  })();

  return refreshPromise;
}

export async function syncLoggedUser() {
  try {
    const user = await authApi.getLoggedUser();
    authStore.setUser(user);
    return user;
  } catch (error) {
    if (isAxiosError(error) && error.response?.status === 404) {
      authStore.setUser(null);
      return null;
    }

    throw error;
  }
}
