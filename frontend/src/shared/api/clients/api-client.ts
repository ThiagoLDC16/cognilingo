import axios, { AxiosHeaders, isAxiosError, type InternalAxiosRequestConfig } from 'axios';

import { refreshAuthSession } from '@/features/auth/services/auth-session';
import { authStore } from '@/features/auth/store/auth-store';
import { env } from '@/shared/config/env';

interface RetryableRequestConfig extends InternalAxiosRequestConfig {
  _retry?: boolean;
}

const AUTH_EXCLUDED_PATHS = ['/api/auth/login', '/api/auth/register', '/api/auth/refresh'];

export const apiClient = axios.create({
  baseURL: env.apiBaseUrl,
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

apiClient.interceptors.request.use((config) => {
  const accessToken = authStore.getState().accessToken;

  if (!accessToken) {
    return config;
  }

  config.headers = new AxiosHeaders(config.headers);
  config.headers.set('Authorization', `Bearer ${accessToken}`);

  return config;
});

apiClient.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (!isAxiosError(error)) {
      return Promise.reject(error);
    }

    const originalRequest = error.config as RetryableRequestConfig | undefined;
    const requestUrl = originalRequest?.url ?? '';
    const shouldSkipRefresh = AUTH_EXCLUDED_PATHS.some((path) => requestUrl.includes(path));

    if (
      error.response?.status !== 401 ||
      !originalRequest ||
      originalRequest._retry ||
      shouldSkipRefresh
    ) {
      return Promise.reject(error);
    }

    originalRequest._retry = true;

    const refreshedTokens = await refreshAuthSession();

    if (!refreshedTokens) {
      return Promise.reject(error);
    }

    originalRequest.headers = new AxiosHeaders(originalRequest.headers);
    originalRequest.headers.set('Authorization', `Bearer ${refreshedTokens.accessToken}`);

    return apiClient(originalRequest);
  },
);
