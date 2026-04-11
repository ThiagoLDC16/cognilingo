import type { AuthUser } from '@/features/auth/types/auth-types';

export interface AuthTokensResponse {
  accessToken: string;
  refreshToken: string;
}

export interface LoginPayload {
  email: string;
  password: string;
}

export interface RegisterPayload {
  name: string;
  email: string;
  password: string;
}

export type LoggedUserResponse = AuthUser;
