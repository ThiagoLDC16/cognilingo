import { useSyncExternalStore } from 'react';

import type { AuthTokensResponse } from '@/features/auth/api/auth-api/types';
import type { AuthState, AuthUser } from '@/features/auth/types/auth-types';

const initialState: AuthState = {
  accessToken: null,
  refreshToken: null,
  user: null,
  status: 'unauthenticated',
  isHydrating: true,
};

class AuthStore {
  private listeners = new Set<() => void>();
  private state: AuthState = initialState;

  subscribe = (listener: () => void) => {
    this.listeners.add(listener);

    return () => {
      this.listeners.delete(listener);
    };
  };

  getState = () => this.state;

  setState = (updater: Partial<AuthState> | ((state: AuthState) => AuthState)) => {
    this.state =
      typeof updater === 'function'
        ? updater(this.state)
        : {
            ...this.state,
            ...updater,
          };

    this.listeners.forEach((listener) => listener());
  };

  setTokens = (tokens: AuthTokensResponse | null) => {
    this.setState({
      accessToken: tokens?.accessToken ?? null,
      refreshToken: tokens?.refreshToken ?? null,
      status: tokens ? 'authenticated' : 'unauthenticated',
    });
  };

  setUser = (user: AuthUser | null) => {
    this.setState({ user });
  };
}

export const authStore = new AuthStore();

export function useAuthStore<T>(selector: (state: AuthState) => T) {
  return useSyncExternalStore(
    authStore.subscribe,
    () => selector(authStore.getState()),
    () => selector(authStore.getState()),
  );
}
