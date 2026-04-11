import '../global.css';

import { Stack } from 'expo-router';
import { StatusBar } from 'expo-status-bar';
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import { SafeAreaProvider } from 'react-native-safe-area-context';

import { AuthBootstrap } from '@/features/auth/components/auth-bootstrap';

export default function RootLayout() {
  return (
    <GestureHandlerRootView className="flex-1 bg-slate-50">
      <SafeAreaProvider>
        <StatusBar style="dark" />
        <AuthBootstrap>
          <Stack screenOptions={{ headerShown: false }}>
            <Stack.Screen name="index" />
            <Stack.Screen name="(auth)" />
            <Stack.Screen name="(app)" />
          </Stack>
        </AuthBootstrap>
      </SafeAreaProvider>
    </GestureHandlerRootView>
  );
}
