import { ActivityIndicator, Text, TouchableOpacity, type TouchableOpacityProps } from 'react-native';

interface ButtonProps extends TouchableOpacityProps {
  title: string;
  loading?: boolean;
  variant?: 'primary' | 'secondary' | 'outline';
}

export const Button = ({
  title,
  loading = false,
  variant = 'primary',
  className = '',
  disabled,
  ...props
}: ButtonProps) => {
  const baseClasses = 'h-12 w-full rounded-2xl items-center justify-center flex-row px-4';

  const variantClasses = {
    primary: 'bg-blue-600 active:bg-blue-700',
    secondary: 'bg-indigo-100 active:bg-indigo-200',
    outline: 'bg-transparent border-2 border-slate-200 active:bg-slate-50',
  };

  const textClasses = {
    primary: 'text-white font-semibold text-base',
    secondary: 'text-indigo-700 font-semibold text-base',
    outline: 'text-slate-700 font-semibold text-base',
  };

  const disabledClasses = disabled || loading ? 'opacity-50' : '';

  return (
    <TouchableOpacity
      className={`${baseClasses} ${variantClasses[variant]} ${disabledClasses} ${className}`}
      disabled={disabled || loading}
      activeOpacity={0.8}
      {...props}
    >
      {loading ? (
        <ActivityIndicator color={variant === 'primary' ? 'white' : '#4f46e5'} className="mr-2" />
      ) : null}
      <Text className={textClasses[variant]}>{title}</Text>
    </TouchableOpacity>
  );
};
