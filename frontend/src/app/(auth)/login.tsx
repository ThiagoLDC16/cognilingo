import { zodResolver } from '@hookform/resolvers/zod';
import { Link } from 'expo-router';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { useTranslation } from 'react-i18next';
import { KeyboardAvoidingView, Platform, ScrollView, Text, View } from 'react-native';
import { z } from 'zod';

import { authApi } from '@/features/auth/api/auth-api';
import { authStore } from '@/features/auth/store/auth-store';
import { Button } from '@/shared/components/Button';
import { ControlledInput } from '@/shared/components/ControlledInput';

const loginSchema = z.object({
  email: z.string().email('Please enter a valid email address'),
  password: z.string().min(6, 'Password must be at least 6 characters'),
});

type LoginForm = z.infer<typeof loginSchema>;

export default function LoginScreen() {
  const { t } = useTranslation();
  const [isLoading, setIsLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState('');

  const { control, handleSubmit } = useForm<LoginForm>({
    resolver: zodResolver(loginSchema),
    defaultValues: { email: '', password: '' },
  });

  const onSubmit = async (data: LoginForm) => {
    setIsLoading(true);
    setErrorMsg('');
    try {
      const tokens = await authApi.login(data);
      authStore.getState().setTokens(tokens);

      const user = await authApi.getLoggedUser();
      authStore.getState().setUser(user);
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
          <Text className="text-4xl font-extrabold text-blue-600 mb-2">Cognilingo</Text>
          <Text className="text-lg text-slate-500">Welcome back!</Text>
        </View>

        {errorMsg ? (
          <Text className="text-red-500 text-center mb-4 font-medium">{errorMsg}</Text>
        ) : null}

        <ControlledInput
          name="email"
          control={control}
          label="Email"
          placeholder="Enter your email"
          keyboardType="email-address"
          autoCapitalize="none"
        />

        <ControlledInput
          name="password"
          control={control}
          label="Password"
          placeholder="Enter your password"
          secureTextEntry
        />

        <Button
          title="Login"
          onPress={handleSubmit(onSubmit)}
          loading={isLoading}
          className="mt-6"
        />

        <View className="flex-row justify-center mt-6 gap-1">
          <Text className="text-slate-600">Don't have an account?</Text>
          <Link href="/(auth)/register" asChild>
            <Text className="text-blue-600 font-semibold">Sign up</Text>
          </Link>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  );
}
