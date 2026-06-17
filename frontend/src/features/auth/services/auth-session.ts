import axios from 'axios';

import { env } from '@/shared/config/env';

import { authStore } from '../store/auth-store';

import type { AuthTokensResponse } from '../api/auth-api/types';

export const refreshAuthSession = async (): Promise<{ accessToken: string; refreshToken: string } | null> => {
  const state = authStore.getState();
  const refreshToken = state.refreshToken;

  if (!refreshToken) {
    state.logout();
    return null;
  }

  try {
    const response = await axios.post<AuthTokensResponse>(
      `${env.apiBaseUrl}/api/auth/refresh`,
      { refreshToken },
      {
        headers: { 'Content-Type': 'application/json' },
        timeout: 15000,
      },
    );
    const tokens = response.data;
    state.setTokens(tokens);
    return tokens;
  } catch {
    state.logout();
    return null;
  }
};
