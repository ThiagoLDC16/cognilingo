import { Link } from 'expo-router';
import { KeyboardAvoidingView, Platform, Text, View } from 'react-native';

import { Screen } from '@/shared/components/screen';

import type { PropsWithChildren } from 'react';

interface AuthShellProps extends PropsWithChildren {
  eyebrow: string;
  title: string;
  subtitle: string;
  footerLabel: string;
  footerCta: string;
  footerHref: '/(auth)/login' | '/(auth)/register';
}

export function AuthShell({
  children,
  eyebrow,
  title,
  subtitle,
  footerCta,
  footerHref,
  footerLabel,
}: AuthShellProps) {
  return (
    <KeyboardAvoidingView
      behavior={Platform.OS === 'ios' ? 'padding' : undefined}
      className="flex-1 bg-slate-50">
      <Screen contentClassName="justify-center">
        <View className="gap-8">
          <View className="gap-3">
            <Text className="text-sm font-semibold uppercase tracking-[2px] text-brand-700">
              {eyebrow}
            </Text>
            <Text className="text-4xl font-bold leading-tight text-slate-950">{title}</Text>
            <Text className="text-base leading-7 text-slate-600">{subtitle}</Text>
          </View>

          <View className="rounded-[28px] bg-white p-6 shadow-card">{children}</View>

          <View className="flex-row items-center justify-center gap-1">
            <Text className="text-sm text-slate-500">{footerLabel}</Text>
            <Link href={footerHref}>
              <Text className="text-sm font-semibold text-brand-700">{footerCta}</Text>
            </Link>
          </View>
        </View>
      </Screen>
    </KeyboardAvoidingView>
  );
}
