import { forwardRef } from 'react';
import { Text, TextInput, View, type TextInputProps } from 'react-native';

export interface InputProps extends TextInputProps {
  label?: string;
  error?: string;
}

export const Input = forwardRef<TextInput, InputProps>(
  ({ label, error, className = '', ...props }, ref) => {
    return (
      <View className={`w-full mb-4 ${className}`}>
        {label ? <Text className="mb-2 text-sm font-medium text-slate-700">{label}</Text> : null}
        <TextInput
          ref={ref}
          className={`h-12 w-full rounded-xl border px-4 text-base text-slate-900 ${error ? 'border-red-500 bg-red-50 focus:border-red-500' : 'border-slate-200 bg-white focus:border-blue-500'}`}
          placeholderTextColor="#94a3b8"
          {...props}
        />
        {error ? <Text className="mt-1 text-sm text-red-500">{error}</Text> : null}
      </View>
    );
  }
);

Input.displayName = 'Input';
