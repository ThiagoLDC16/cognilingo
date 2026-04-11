import type {
  AuthTokensResponse,
  LoggedUserResponse,
  LoginPayload,
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
};
