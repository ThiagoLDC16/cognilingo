import { Stack, useLocalSearchParams } from 'expo-router';
import { View } from 'react-native';

export default function SituationsScreen() {
  const { categoryId, name } = useLocalSearchParams<{
    categoryId: string;
    name: string;
  }>();

  return (
    <View style={{ flex: 1 }}>
      <Stack.Screen options={{ title: name }} />
    </View>
  );
}