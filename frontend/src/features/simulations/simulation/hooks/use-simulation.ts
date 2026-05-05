import { useCallback, useEffect, useState } from 'react';

import { simulationsApi } from '@/features/simulations/api/simulations-api';
import { MessageSender, type SimulationMessage } from '@/features/simulations/api/simulations-api/types';

interface UseSimulationState {
  messages: SimulationMessage[];
  isLoading: boolean;
  isSending: boolean;
  isFinishing: boolean;
  error: string | null;
}

let optimisticIdCounter = 0;

export function useSimulation(simulationId: string) {
  const [state, setState] = useState<UseSimulationState>({
    messages: [],
    isLoading: true,
    isSending: false,
    isFinishing: false,
    error: null,
  });

  useEffect(() => {
    let cancelled = false;

    const fetchMessages = async () => {
      setState((prev) => ({ ...prev, isLoading: true, error: null }));
      try {
        const messages = await simulationsApi.listMessages(simulationId);
        if (!cancelled) {
          setState({ messages, isLoading: false, isSending: false, isFinishing: false, error: null });
        }
      } catch {
        if (!cancelled) {
          setState({ messages: [], isLoading: false, isSending: false, isFinishing: false, error: 'internalError' });
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
      const optimisticMessage: SimulationMessage = {
        id: `optimistic-${++optimisticIdCounter}`,
        sender: MessageSender.USER,
        content,
        translatedContent: null,
        feedback: null,
      };

      setState((prev) => ({
        ...prev,
        messages: [...prev.messages, optimisticMessage],
        isSending: true,
        error: null,
      }));

      try {
        const newMessages = await simulationsApi.sendMessage(simulationId, content);
        setState((prev) => ({
          ...prev,
          // Replace the optimistic message with the real ones from the API
          messages: [
            ...prev.messages.filter((m) => m.id !== optimisticMessage.id),
            ...newMessages,
          ],
          isSending: false,
        }));
      } catch {
        setState((prev) => ({
          ...prev,
          // Remove the optimistic message on error
          messages: prev.messages.filter((m) => m.id !== optimisticMessage.id),
          isSending: false,
          error: 'internalError',
        }));
      }
    },
    [simulationId],
  );

  const finishSimulation = useCallback(async () => {
    setState((prev) => ({ ...prev, isFinishing: true, error: null }));
    try {
      await simulationsApi.finishSimulation(simulationId);
    } catch {
      setState((prev) => ({ ...prev, isFinishing: false, error: 'internalError' }));
      throw new Error('internalError');
    }
  }, [simulationId]);

  return { ...state, sendMessage, finishSimulation };
}
