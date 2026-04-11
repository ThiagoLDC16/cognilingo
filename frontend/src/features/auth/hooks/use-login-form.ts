import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'expo-router';
import { useState } from 'react';
import { useForm } from 'react-hook-form';

import { signIn } from '@/features/auth/store/auth-actions';
import { loginSchema, type LoginFormValues } from '@/features/auth/types/auth-schemas';
import { getApiErrorMessage } from '@/shared/utils/api-error';

export function useLoginForm() {
  const router = useRouter();
  const [apiError, setApiError] = useState<string | null>(null);

  const form = useForm<LoginFormValues>({
    defaultValues: {
      email: '',
      password: '',
    },
    resolver: zodResolver(loginSchema),
  });

  const onSubmit = form.handleSubmit(async (values) => {
    setApiError(null);

    try {
      await signIn(values);
      router.replace('/(app)');
    } catch (error) {
      setApiError(getApiErrorMessage(error, 'Não foi possível entrar. Tente novamente.'));
    }
  });

  return {
    apiError,
    form,
    onSubmit,
  };
}
