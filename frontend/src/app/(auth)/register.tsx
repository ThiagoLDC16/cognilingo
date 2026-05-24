import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'expo-router';
import { useMemo, useState } from 'react';
import { useForm } from 'react-hook-form';
import { useTranslation } from 'react-i18next';
import { KeyboardAvoidingView, Platform, ScrollView, Text, View } from 'react-native';
import { z } from 'zod';

import { authApi } from '@/features/auth/api/auth-api';
import { authStore } from '@/features/auth/store/auth-store';
import { Button } from '@/shared/components/Button';
import { ControlledInput } from '@/shared/components/ControlledInput';

type RegisterForm = { name: string; email: string; password: string };

export default function RegisterScreen() {
  const { t } = useTranslation();
  const router = useRouter();
  const [isLoading, setIsLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState('');

  const registerSchema = useMemo(
    () =>
      z.object({
        name: z.string().min(2, t('register.validation.name')),
        email: z.string().email(t('register.validation.email')),
        password: z.string().min(6, t('register.validation.password')),
      }),
    [t],
  );

  const { control, handleSubmit } = useForm<RegisterForm>({
    resolver: zodResolver(registerSchema),
    defaultValues: { name: '', email: '', password: '' },
  });

  const onSubmit = async (data: RegisterForm) => {
    setIsLoading(true);
    setErrorMsg('');
    try {
      const tokens = await authApi.register(data);
      authStore.getState().setTokens(tokens);

      const user = await authApi.getLoggedUser();
      authStore.getState().setUser(user);
      router.replace('/(onboarding)/setup');
    } catch (e: any) {
      if (e.response?.data?.errors?.length) {
        setErrorMsg(t(e.response.data.errors[0]));
      } else {
        setErrorMsg(t('internalError'));
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <KeyboardAvoidingView
      behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
      className="flex-1 bg-white"
    >
      <ScrollView contentContainerStyle={{ flexGrow: 1, justifyContent: 'center', padding: 24 }}>
        <View className="items-center mb-10">
          <Text className="text-3xl font-bold text-slate-900 mb-2">{t('register.heading')}</Text>
          <Text className="text-base text-slate-500">{t('register.subtitle')}</Text>
        </View>

        {errorMsg ? (
          <Text className="text-red-500 text-center mb-4 font-medium">{errorMsg}</Text>
        ) : null}

        <ControlledInput
          name="name"
          control={control}
          label={t('register.name.label')}
          placeholder={t('register.name.placeholder')}
          autoCapitalize="words"
        />

        <ControlledInput
          name="email"
          control={control}
          label={t('register.email.label')}
          placeholder={t('register.email.placeholder')}
          keyboardType="email-address"
          autoCapitalize="none"
        />

        <ControlledInput
          name="password"
          control={control}
          label={t('register.password.label')}
          placeholder={t('register.password.placeholder')}
          secureTextEntry
        />

        <Button
          title={t('register.button')}
          onPress={handleSubmit(onSubmit)}
          loading={isLoading}
          className="mt-6"
        />

        <View className="flex-row justify-center mt-6 gap-1">
          <Text className="text-slate-600">{t('register.hasAccount')}</Text>
          <Text
            className="text-blue-600 font-semibold"
            onPress={() => router.back()}
          >
            {t('register.logIn')}
          </Text>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  );
}
