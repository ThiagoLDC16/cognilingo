import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'expo-router';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { useTranslation } from 'react-i18next';
import { KeyboardAvoidingView, Platform, ScrollView, Text, View } from 'react-native';
import { z } from 'zod';

import { authApi } from '@/features/auth/api/auth-api';
import { authStore } from '@/features/auth/store/auth-store';
import { Button } from '@/shared/components/Button';
import { ControlledInput } from '@/shared/components/ControlledInput';

const registerSchema = z.object({
  name: z.string().min(2, 'Name must be at least 2 characters'),
  email: z.string().email('Please enter a valid email address'),
  password: z.string().min(6, 'Password must be at least 6 characters'),
});

type RegisterForm = z.infer<typeof registerSchema>;

export default function RegisterScreen() {
  const { t } = useTranslation();
  const router = useRouter();
  const [isLoading, setIsLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState('');

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
          <Text className="text-3xl font-bold text-slate-900 mb-2">Create Account</Text>
          <Text className="text-base text-slate-500">Join Cognilingo to start learning</Text>
        </View>

        {errorMsg ? (
          <Text className="text-red-500 text-center mb-4 font-medium">{errorMsg}</Text>
        ) : null}

        <ControlledInput
          name="name"
          control={control}
          label="Name"
          placeholder="Enter your name"
          autoCapitalize="words"
        />

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
          placeholder="Create a password"
          secureTextEntry
        />

        <Button
          title="Sign Up"
          onPress={handleSubmit(onSubmit)}
          loading={isLoading}
          className="mt-6"
        />

        <View className="flex-row justify-center mt-6 gap-1">
          <Text className="text-slate-600">Already have an account?</Text>
          <Text
            className="text-blue-600 font-semibold"
            onPress={() => router.back()}
          >
            Log in
          </Text>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  );
}
