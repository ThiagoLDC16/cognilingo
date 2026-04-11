import { ActivityIndicator, Text, View } from 'react-native';

import { Screen } from '@/shared/components/screen';

interface LoadingScreenProps {
  message: string;
}

export function LoadingScreen({ message }: LoadingScreenProps) {
  return (
    <Screen contentClassName="items-center justify-center">
      <View className="items-center gap-4 rounded-3xl bg-white px-8 py-10 shadow-card">
        <ActivityIndicator color="#0874f0" />
        <Text className="text-base font-medium text-slate-700">{message}</Text>
      </View>
    </Screen>
  );
}
