import { Text, TextInput, View } from 'react-native';

import { cn } from '@/shared/utils/cn';

import type { TextInputProps } from 'react-native';

interface TextFieldProps extends TextInputProps {
  label: string;
  error?: string;
}

export function TextField({ error, label, ...props }: TextFieldProps) {
  return (
    <View className="gap-2">
      <Text className="text-sm font-semibold text-slate-800">{label}</Text>
      <TextInput
        className={cn(
          'min-h-14 rounded-2xl border bg-slate-50 px-4 text-base text-slate-950',
          error ? 'border-red-300' : 'border-slate-200',
        )}
        placeholderTextColor="#94a3b8"
        {...props}
      />
      {error ? <Text className="text-sm text-red-600">{error}</Text> : null}
    </View>
  );
}
