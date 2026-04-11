import * as SecureStore from 'expo-secure-store';

import type { AuthTokensResponse } from '@/features/auth/api/auth-api/types';

const ACCESS_TOKEN_KEY = 'cognilingo.access-token';
const REFRESH_TOKEN_KEY = 'cognilingo.refresh-token';

export async function persistAuthTokens(tokens: AuthTokensResponse) {
  await Promise.all([
    SecureStore.setItemAsync(ACCESS_TOKEN_KEY, tokens.accessToken),
    SecureStore.setItemAsync(REFRESH_TOKEN_KEY, tokens.refreshToken),
  ]);
}

export async function restoreAuthTokens(): Promise<AuthTokensResponse | null> {
  const [accessToken, refreshToken] = await Promise.all([
    SecureStore.getItemAsync(ACCESS_TOKEN_KEY),
    SecureStore.getItemAsync(REFRESH_TOKEN_KEY),
  ]);

  if (!accessToken || !refreshToken) {
    return null;
  }

  return {
    accessToken,
    refreshToken,
  };
}

export async function clearPersistedAuthTokens() {
  await Promise.all([
    SecureStore.deleteItemAsync(ACCESS_TOKEN_KEY),
    SecureStore.deleteItemAsync(REFRESH_TOKEN_KEY),
  ]);
}
