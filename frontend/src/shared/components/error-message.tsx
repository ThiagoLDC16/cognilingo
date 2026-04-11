import { Text, View } from 'react-native';

interface ErrorMessageProps {
  message: string;
}

export function ErrorMessage({ message }: ErrorMessageProps) {
  return (
    <View className="rounded-2xl border border-red-100 bg-red-50 px-4 py-3">
      <Text className="text-sm leading-6 text-red-700">{message}</Text>
    </View>
  );
}
