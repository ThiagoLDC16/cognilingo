import { Stack, useLocalSearchParams } from 'expo-router';
import { View } from 'react-native';

export default function VariantsScreen() {
  const { situationId, name } = useLocalSearchParams<{
    situationId: string;
    name: string;
  }>();

  return (
    <View style={{ flex: 1 }}>
      <Stack.Screen options={{ title: name }} />
    </View>
  );
}