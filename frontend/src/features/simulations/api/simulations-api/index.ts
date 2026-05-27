import { apiClient } from '@/shared/api/clients/api-client';

import type { Category, SimulationMessage, Situation, TranslateMessageResponse, Variant } from './types';

export const simulationsApi = {
  async listCategories(languageCode: string) {
    const response = await apiClient.get<Category[]>('/api/simulations/categories', {
      params: { languageCode },
    });
    return response.data;
  },

  async listSituations(categoryId: string, languageCode: string) {
    const response = await apiClient.get<Situation[]>(
      `/api/simulations/categories/${categoryId}/situations`,
      { params: { languageCode } },
    );
    return response.data;
  },

  async listVariants(situationId: string, languageCode: string) {
    const response = await apiClient.get<Variant[]>(
      `/api/simulations/situations/${situationId}/variants`,
      { params: { languageCode } },
    );
    return response.data;
  },

  async startSimulation(variantId: string) {
    const response = await apiClient.post<string>('/api/simulations', { variantId });
    return response.data;
  },

  async listMessages(simulationId: string) {
    const response = await apiClient.get<SimulationMessage[]>(
      `/api/simulations/${simulationId}/messages`,
    );
    return response.data;
  },

  async sendMessage(simulationId: string, content: string) {
    const response = await apiClient.post<SimulationMessage[]>(
      `/api/simulations/${simulationId}/messages`,
      { content },
    );
    return response.data;
  },

  async translateMessage(simulationId: string, messageId: string) {
    const response = await apiClient.post<TranslateMessageResponse>(
      `/api/simulations/${simulationId}/messages/${messageId}/translate`,
    );
    return response.data;
  },

  async finishSimulation(simulationId: string) {
    await apiClient.post(`/api/simulations/${simulationId}/finish`);
  },
};
