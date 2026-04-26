import { create } from 'zustand';

import { storage } from '@/shared/utils/storage';

import type { AuthUser } from '../types/auth-types';

interface AuthTokens {
  accessToken: string;
  refreshToken: string;
}

interface AuthStoreState {
  user: AuthUser | null;
  accessToken: string | null;
  refreshToken: string | null;
  isReady: boolean;
  setAuth: (payload: { user: AuthUser; tokens: AuthTokens }) => void;
  setTokens: (tokens: AuthTokens) => void;
  setUser: (user: AuthUser) => void;
  logout: () => void;
  setReady: (state: boolean) => void;
}

export const authStore = create<AuthStoreState>((set) => ({
  user: null,
  accessToken: null,
  refreshToken: null,
  isReady: false,

  setAuth: (payload) => {
    storage.setItem('accessToken', payload.tokens.accessToken);
    storage.setItem('refreshToken', payload.tokens.refreshToken);
    set({
      user: payload.user,
      accessToken: payload.tokens.accessToken,
      refreshToken: payload.tokens.refreshToken,
    });
  },

  setTokens: (tokens) => {
    storage.setItem('accessToken', tokens.accessToken);
    storage.setItem('refreshToken', tokens.refreshToken);
    set({
      accessToken: tokens.accessToken,
      refreshToken: tokens.refreshToken,
    });
  },

  setUser: (user) => {
    set({ user });
  },

  logout: () => {
    storage.removeItem('accessToken');
    storage.removeItem('refreshToken');
    set({ user: null, accessToken: null, refreshToken: null });
  },

  setReady: (state) => set({ isReady: state }),
}));

export const useLoggedUser = () => authStore((state) => state.user);
