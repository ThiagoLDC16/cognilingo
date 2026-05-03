import * as Localization from 'expo-localization';
import { useEffect, useState } from 'react';

import { simulationsApi } from '@/features/simulations/api/simulations-api';
import type { Situation } from '@/features/simulations/api/simulations-api/types';

interface UseSituationsState {
  situations: Situation[];
  isLoading: boolean;
  error: string | null;
}

export function useSituations(categoryId: string) {
  const [state, setState] = useState<UseSituationsState>({
    situations: [],
    isLoading: true,
    error: null,
  });

  const languageCode = Localization.getLocales()[0]?.languageCode ?? 'en';

  useEffect(() => {
    let cancelled = false;

    const fetchSituations = async () => {
      setState((prev) => ({ ...prev, isLoading: true, error: null }));
      try {
        const situations = await simulationsApi.listSituations(categoryId, languageCode);
        if (!cancelled) {
          setState({ situations, isLoading: false, error: null });
        }
      } catch {
        if (!cancelled) {
          setState({ situations: [], isLoading: false, error: 'internalError' });
        }
      }
    };

    fetchSituations();
    return () => {
      cancelled = true;
    };
  }, [categoryId, languageCode]);

  return state;
}
