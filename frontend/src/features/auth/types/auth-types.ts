export interface AuthUser {
  id: string;
  name: string;
  hasProfile: boolean;
}

export interface AuthState {
  accessToken: string | null;
  refreshToken: string | null;
  user: AuthUser | null;
  status: 'authenticated' | 'unauthenticated';
  isHydrating: boolean;
}
