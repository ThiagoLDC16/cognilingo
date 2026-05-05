import { Stack, useRouter } from 'expo-router';
import { ScrollView, View } from 'react-native';

import { CompletedActions } from '../components/simulation-completed/completed-actions';
import { CompletedHeader } from '../components/simulation-completed/completed-header';
import { MetricGrid } from '../components/simulation-completed/metric-grid';

export default function SimulationCompletedScreen() {
  const router = useRouter();

  const handleNextSimulation = () => {
    router.dismissAll();
  };

  const handleReturnToDashboard = () => {
    router.dismissAll();
  };

  return (
    <ScrollView
      className="flex-1 bg-md-background"
      contentContainerClassName="px-6 pt-16 pb-8 gap-8 flex-grow"
    >
      <Stack.Screen options={{ headerShown: false }} />

      <CompletedHeader />

      <View className="gap-4 flex-1">
        <MetricGrid />
      </View>

      <CompletedActions
        onNextSimulation={handleNextSimulation}
        onReturnToDashboard={handleReturnToDashboard}
      />
    </ScrollView>
  );
}
