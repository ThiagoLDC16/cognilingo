import { Redirect } from 'expo-router';

import { useAuthStore } from '@/features/auth/store/auth-store';

export default function IndexRoute() {
  const status = useAuthStore((state) => state.status);

  return <Redirect href={status === 'authenticated' ? '/(app)' : '/(auth)/login'} />;
}
