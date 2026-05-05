import { MaterialIcons } from '@expo/vector-icons';
import { useTranslation } from 'react-i18next';
import { Text, View } from 'react-native';

const METRICS = [
  { icon: 'spellcheck' as const, labelKey: 'simulation.completed.grammar', color: '#00677f' },
  { icon: 'menu-book' as const, labelKey: 'simulation.completed.vocabulary', color: '#b75600' },
  { icon: 'record-voice-over' as const, labelKey: 'simulation.completed.fluency', color: '#4343d5' },
];

function MetricItem({ icon, labelKey, color }: { icon: keyof typeof MaterialIcons.glyphMap; labelKey: string; color: string }) {
  const { t } = useTranslation();

  return (
    <View
      className="flex-1 bg-md-surface rounded-xl p-4 items-center justify-center gap-2 border border-md-surface-container-highest"
      style={{ borderCurve: 'continuous', boxShadow: '0 4px 12px rgba(93, 95, 239, 0.04)' }}
    >
      <MaterialIcons name={icon} size={24} color={color} />
      <Text className="text-xs font-medium tracking-wider text-md-on-surface-variant">
        {t(labelKey)}
      </Text>
      <View className="w-2 h-2 rounded-full" style={{ backgroundColor: color }} />
    </View>
  );
}

export function MetricGrid() {
  return (
    <View className="flex-row gap-2">
      {METRICS.map((metric) => (
        <MetricItem key={metric.labelKey} {...metric} />
      ))}
    </View>
  );
}
