import { useTranslation } from 'react-i18next';
import { Text, View } from 'react-native';

export function SimulationStartedBadge() {
  const { t } = useTranslation();

  return (
    <View className="items-center">
      <View className="bg-md-surface-container px-4 py-1 rounded-full">
        <Text className="text-xs text-md-outline">
          {t('simulation.started')}
        </Text>
      </View>
    </View>
  );
}
