import type {
  AuthTokensResponse,
  LoggedUserResponse,
  LoginPayload,
  LogoutPayload,
  RegisterPayload,
} from '@/features/auth/api/auth-api/types';
import { apiClient } from '@/shared/api/clients/api-client';

export const authApi = {
  async login(payload: LoginPayload) {
    const response = await apiClient.post<AuthTokensResponse>('/api/auth/login', payload);
    return response.data;
  },
  async register(payload: RegisterPayload) {
    const response = await apiClient.post<AuthTokensResponse>('/api/auth/register', payload);
    return response.data;
  },
  async getLoggedUser() {
    const response = await apiClient.get<LoggedUserResponse>('/api/auth/logged-user');
    return response.data;
  },
  async refreshTokens(payload: { refreshToken: string }) {
    const response = await apiClient.post<AuthTokensResponse>('/api/auth/refresh', payload);
    return response.data;
  },
  async logout(payload: LogoutPayload) {
    await apiClient.post('/api/auth/logout', payload);
  },
};
