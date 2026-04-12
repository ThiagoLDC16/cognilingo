import { authApi } from '../api/auth-api';
import { authStore } from '../store/auth-store';

export const refreshAuthSession = async (): Promise<{ accessToken: string; refreshToken: string } | null> => {
  const state = authStore.getState();
  const refreshToken = state.refreshToken;

  if (!refreshToken) {
    state.logout();
    return null;
  }

  try {
    const tokens = await authApi.refreshTokens({ refreshToken });
    state.setTokens(tokens);
    return tokens;
  } catch (error) {
    state.logout();
    return null;
  }
};
