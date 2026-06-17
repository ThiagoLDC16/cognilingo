import * as Localization from 'expo-localization';
import { useEffect, useState } from 'react';

import { simulationsApi } from '@/features/simulations/api/simulations-api';
import type { Category } from '@/features/simulations/api/simulations-api/types';

interface UseCategoriesState {
  categories: Category[];
  isLoading: boolean;
  error: string | null;
}

export function useCategories() {
  const [state, setState] = useState<UseCategoriesState>({
    categories: [],
    isLoading: true,
    error: null,
  });

  const languageCode = Localization.getLocales()[0]?.languageTag ?? 'en-US';

  useEffect(() => {
    let cancelled = false;

    const fetchCategories = async () => {
      setState((prev) => ({ ...prev, isLoading: true, error: null }));
      try {
        const categories = await simulationsApi.listCategories(languageCode);
        if (!cancelled) {
          setState({ categories, isLoading: false, error: null });
        }
      } catch {
        if (!cancelled) {
          setState({ categories: [], isLoading: false, error: 'internalError' });
        }
      }
    };

    fetchCategories();

    return () => {
      cancelled = true;
    };
  }, [languageCode]);

  return state;
}
