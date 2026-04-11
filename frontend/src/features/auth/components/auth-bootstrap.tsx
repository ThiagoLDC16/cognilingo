import { type PropsWithChildren, useEffect } from 'react';

import { bootstrapAuthSession } from '@/features/auth/store/auth-actions';
import { useAuthStore } from '@/features/auth/store/auth-store';
import { LoadingScreen } from '@/shared/components/loading-screen';

export function AuthBootstrap({ children }: PropsWithChildren) {
  const isHydrating = useAuthStore((state) => state.isHydrating);

  useEffect(() => {
    void bootstrapAuthSession();
  }, []);

  if (isHydrating) {
    return <LoadingScreen message="Restaurando sessão..." />;
  }

  return children;
}
