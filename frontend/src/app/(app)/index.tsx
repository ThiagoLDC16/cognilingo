import { ScrollView, Text, View } from 'react-native';

import { authStore, useLoggedUser } from '@/features/auth/store/auth-store';
import { Button } from '@/shared/components/Button';

export default function Home() {
  const user = useLoggedUser();

  return (
    <ScrollView
      contentInsetAdjustmentBehavior="automatic"
      contentContainerStyle={{ flexGrow: 1, padding: 24, gap: 16 }}
    >
      <View className="flex-1 items-center justify-center gap-6">
        <Text className="text-center text-3xl font-bold text-slate-800">
          Welcome {user?.name || 'User'}!
        </Text>
        <Text className="px-4 text-center text-base text-slate-500">
          This is the home screen for your Cognilingo dashboard.
        </Text>

        <View className="mt-8 w-full max-w-sm">
          <Button title="Log Out" variant="outline" onPress={() => authStore.getState().logout()} />
        </View>
      </View>
    </ScrollView>
  );
}
