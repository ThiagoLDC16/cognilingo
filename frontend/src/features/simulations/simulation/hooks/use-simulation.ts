import { useCallback, useEffect, useState } from 'react';

import { simulationsApi } from '@/features/simulations/api/simulations-api';
import type { SimulationMessage } from '@/features/simulations/api/simulations-api/types';

interface UseSimulationState {
  messages: SimulationMessage[];
  isLoading: boolean;
  isSending: boolean;
  error: string | null;
}

export function useSimulation(simulationId: string) {
  const [state, setState] = useState<UseSimulationState>({
    messages: [],
    isLoading: true,
    isSending: false,
    error: null,
  });

  useEffect(() => {
    let cancelled = false;

    const fetchMessages = async () => {
      setState((prev) => ({ ...prev, isLoading: true, error: null }));
      try {
        const messages = await simulationsApi.listMessages(simulationId);
        if (!cancelled) {
          setState({ messages, isLoading: false, isSending: false, error: null });
        }
      } catch {
        if (!cancelled) {
          setState({ messages: [], isLoading: false, isSending: false, error: 'internalError' });
        }
      }
    };

    fetchMessages();
    return () => {
      cancelled = true;
    };
  }, [simulationId]);

  const sendMessage = useCallback(
    async (content: string) => {
      setState((prev) => ({ ...prev, isSending: true, error: null }));
      try {
        const newMessages = await simulationsApi.sendMessage(simulationId, content);
        setState((prev) => ({
          ...prev,
          messages: [...prev.messages, ...newMessages],
          isSending: false,
        }));
      } catch {
        setState((prev) => ({ ...prev, isSending: false, error: 'internalError' }));
      }
    },
    [simulationId],
  );

  return { ...state, sendMessage };
}
