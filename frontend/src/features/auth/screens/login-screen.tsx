import { Controller } from 'react-hook-form';
import { Text, View } from 'react-native';

import { AuthShell } from '@/features/auth/components/auth-shell';
import { useLoginForm } from '@/features/auth/hooks/use-login-form';
import { AppButton } from '@/shared/components/app-button';
import { ErrorMessage } from '@/shared/components/error-message';
import { TextField } from '@/shared/components/text-field';

export function LoginScreen() {
  const {
    apiError,
    form: {
      control,
      formState: { errors, isSubmitting },
    },
    onSubmit,
  } = useLoginForm();

  return (
    <AuthShell
      eyebrow="Acesse sua conta"
      title="Continue sua jornada no Cognilingo"
      subtitle="Entre com suas credenciais para sincronizar progresso, sessões e preferências."
      footerLabel="Ainda não tem conta?"
      footerCta="Criar conta"
      footerHref="/(auth)/register">
      <View className="gap-5">
        {apiError ? <ErrorMessage message={apiError} /> : null}

        <Controller
          control={control}
          name="email"
          render={({ field: { onBlur, onChange, value } }) => (
            <TextField
              autoCapitalize="none"
              autoComplete="email"
              error={errors.email?.message}
              keyboardType="email-address"
              label="E-mail"
              onBlur={onBlur}
              onChangeText={onChange}
              placeholder="voce@exemplo.com"
              value={value}
            />
          )}
        />

        <Controller
          control={control}
          name="password"
          render={({ field: { onBlur, onChange, value } }) => (
            <TextField
              autoCapitalize="none"
              autoComplete="password"
              error={errors.password?.message}
              label="Senha"
              onBlur={onBlur}
              onChangeText={onChange}
              placeholder="Digite sua senha"
              secureTextEntry
              value={value}
            />
          )}
        />

        <AppButton loading={isSubmitting} title="Entrar" onPress={() => void onSubmit()} />

        <Text className="text-center text-sm leading-6 text-slate-500">
          O app salva a sessão com segurança e renova tokens automaticamente quando necessário.
        </Text>
      </View>
    </AuthShell>
  );
}
