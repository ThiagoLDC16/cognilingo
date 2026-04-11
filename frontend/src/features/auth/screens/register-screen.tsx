import { Controller } from 'react-hook-form';
import { View } from 'react-native';

import { AuthShell } from '@/features/auth/components/auth-shell';
import { useRegisterForm } from '@/features/auth/hooks/use-register-form';
import { AppButton } from '@/shared/components/app-button';
import { ErrorMessage } from '@/shared/components/error-message';
import { TextField } from '@/shared/components/text-field';

export function RegisterScreen() {
  const {
    apiError,
    form: {
      control,
      formState: { errors, isSubmitting },
    },
    onSubmit,
  } = useRegisterForm();

  return (
    <AuthShell
      eyebrow="Crie sua conta"
      title="Comece com uma base pronta para produção"
      subtitle="Cadastro validado com Zod, persistência segura de sessão e navegação protegida."
      footerLabel="Já possui cadastro?"
      footerCta="Entrar"
      footerHref="/(auth)/login">
      <View className="gap-5">
        {apiError ? <ErrorMessage message={apiError} /> : null}

        <Controller
          control={control}
          name="name"
          render={({ field: { onBlur, onChange, value } }) => (
            <TextField
              autoCapitalize="words"
              autoComplete="name"
              error={errors.name?.message}
              label="Nome"
              onBlur={onBlur}
              onChangeText={onChange}
              placeholder="Seu nome"
              value={value}
            />
          )}
        />

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
              autoComplete="new-password"
              error={errors.password?.message}
              label="Senha"
              onBlur={onBlur}
              onChangeText={onChange}
              placeholder="Crie uma senha"
              secureTextEntry
              value={value}
            />
          )}
        />

        <Controller
          control={control}
          name="confirmPassword"
          render={({ field: { onBlur, onChange, value } }) => (
            <TextField
              autoCapitalize="none"
              autoComplete="new-password"
              error={errors.confirmPassword?.message}
              label="Confirmar senha"
              onBlur={onBlur}
              onChangeText={onChange}
              placeholder="Repita sua senha"
              secureTextEntry
              value={value}
            />
          )}
        />

        <AppButton loading={isSubmitting} title="Criar conta" onPress={() => void onSubmit()} />
      </View>
    </AuthShell>
  );
}
