import { apiClient } from '@/shared/api/clients/api-client';

import type { CreateProfilePayload, Language } from './types';

export const onboardingApi = {
  async getLanguages() {
    const response = await apiClient.get<Language[]>('/api/identity/languages');
    return response.data;
  },

  async createProfile(payload: CreateProfilePayload) {
    await apiClient.post('/api/identity/profile', payload);
  },
};
