import * as Localization from 'expo-localization';
import { useEffect, useState } from 'react';

import { simulationsApi } from '@/features/simulations/api/simulations-api';
import type { Variant } from '@/features/simulations/api/simulations-api/types';

interface UseVariantsState {
  variants: Variant[];
  isLoading: boolean;
  error: string | null;
}

export function useVariants(situationId: string) {
  const [state, setState] = useState<UseVariantsState>({
    variants: [],
    isLoading: true,
    error: null,
  });

  const languageCode = Localization.getLocales()[0]?.languageCode ?? 'en';

  useEffect(() => {
    let cancelled = false;

    const fetchVariants = async () => {
      setState((prev) => ({ ...prev, isLoading: true, error: null }));
      try {
        const variants = await simulationsApi.listVariants(situationId, languageCode);
        if (!cancelled) {
          setState({ variants, isLoading: false, error: null });
        }
      } catch {
        if (!cancelled) {
          setState({ variants: [], isLoading: false, error: 'internalError' });
        }
      }
    };

    fetchVariants();
    return () => {
      cancelled = true;
    };
  }, [situationId, languageCode]);

  return state;
}
