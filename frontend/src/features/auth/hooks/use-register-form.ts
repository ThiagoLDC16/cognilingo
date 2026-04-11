import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'expo-router';
import { useState } from 'react';
import { useForm } from 'react-hook-form';

import { signUp } from '@/features/auth/store/auth-actions';
import { registerSchema, type RegisterFormValues } from '@/features/auth/types/auth-schemas';
import { getApiErrorMessage } from '@/shared/utils/api-error';

export function useRegisterForm() {
  const router = useRouter();
  const [apiError, setApiError] = useState<string | null>(null);

  const form = useForm<RegisterFormValues>({
    defaultValues: {
      name: '',
      email: '',
      password: '',
      confirmPassword: '',
    },
    resolver: zodResolver(registerSchema),
  });

  const onSubmit = form.handleSubmit(async ({ confirmPassword: _, ...values }) => {
    setApiError(null);

    try {
      await signUp(values);
      router.replace('/(app)');
    } catch (error) {
      setApiError(getApiErrorMessage(error, 'Não foi possível criar a conta.'));
    }
  });

  return {
    apiError,
    form,
    onSubmit,
  };
}
