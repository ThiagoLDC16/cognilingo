import { Stack } from 'expo-router';

export default function AppLayout() {
  return (
    <Stack
      screenOptions={{
        contentStyle: { backgroundColor: '#F8FAFC' },
      }}
    >
      <Stack.Screen name="index" options={{ headerShown: false }} />
      <Stack.Screen name="(main)" options={{ headerShown: false }} />
      <Stack.Screen name="situations/[categoryId]" />
      <Stack.Screen name="variants/[situationId]" />
      <Stack.Screen
        name="simulation/[simulationId]"
        options={{
          headerTitleAlign: 'center',
        }}
      />
    </Stack>
  );
}
