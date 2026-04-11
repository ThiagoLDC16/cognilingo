import { ActivityIndicator, Pressable, Text } from 'react-native';

import { cn } from '@/shared/utils/cn';

interface AppButtonProps {
  title: string;
  onPress: () => void;
  loading?: boolean;
  disabled?: boolean;
  variant?: 'primary' | 'secondary';
}

export function AppButton({
  title,
  onPress,
  loading = false,
  disabled = false,
  variant = 'primary',
}: AppButtonProps) {
  const isDisabled = disabled || loading;

  return (
    <Pressable
      className={cn(
        'min-h-14 items-center justify-center rounded-2xl px-4',
        variant === 'primary' ? 'bg-brand-600' : 'bg-slate-200',
        isDisabled ? 'opacity-60' : '',
      )}
      disabled={isDisabled}
      onPress={onPress}>
      {loading ? (
        <ActivityIndicator color={variant === 'primary' ? '#ffffff' : '#0f172a'} />
      ) : (
        <Text
          className={cn(
            'text-base font-semibold',
            variant === 'primary' ? 'text-white' : 'text-slate-900',
          )}>
          {title}
        </Text>
      )}
    </Pressable>
  );
}
