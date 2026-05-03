import { Stack, useLocalSearchParams, useRouter } from 'expo-router';
import { Pressable, Text, View } from 'react-native';
import { useTranslation } from 'react-i18next';

export default function SimulationScreen() {
  const { simulationId, name } = useLocalSearchParams<{
    simulationId: string;
    name: string;
  }>();
  const { t } = useTranslation();
  const router = useRouter();

  const handleFinish = () => {
    // TODO: Implement simulation finish logic
    router.back();
  };

  return (
    <View style={{ flex: 1 }}>
      <Stack.Screen
        options={{
          title: name,
          headerTitleAlign: 'center',
          headerRight: () => (
            <Pressable onPress={handleFinish}>
              <Text style={{ color: '#DC2626', fontSize: 16, fontWeight: '600' }}>
                {t('simulation.finish')}
              </Text>
            </Pressable>
          ),
        }}
      />
    </View>
  );
}