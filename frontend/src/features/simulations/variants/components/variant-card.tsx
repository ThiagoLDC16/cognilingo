import { MaterialIcons } from '@expo/vector-icons';
import { useTranslation } from 'react-i18next';
import { Text, View } from 'react-native';

import type { Variant } from '@/features/simulations/api/simulations-api/types';

interface VariantCardProps {
  variant: Variant;
  index: number;
}

const VARIANT_ICONS: (keyof typeof MaterialIcons.glyphMap)[] = [
  'luggage',
  'security',
  'flight',
  'restaurant',
  'shopping-cart',
  'local-taxi',
  'hotel',
  'explore',
];

function VariantObjectives({ objectives }: { objectives: string[] }) {
  const { t } = useTranslation();

  return (
    <View className="mt-2 bg-md-surface rounded-xl p-4 border border-md-outline-variant/20">
      <Text className="text-[11px] font-medium uppercase tracking-widest text-md-on-surface mb-2">
        {t('variants.objectives')}
      </Text>
      <View className="gap-2">
        {objectives.map((objective) => (
          <View key={objective} className="flex-row items-start gap-2">
            <MaterialIcons
              name="arrow-right"
              size={18}
              color="#4343d5"
              style={{ marginTop: 2 }}
            />
            <Text className="text-sm text-md-on-surface-variant flex-1 leading-5">
              {objective}
            </Text>
          </View>
        ))}
      </View>
    </View>
  );
}

export function VariantCard({ variant, index }: VariantCardProps) {
  const icon = VARIANT_ICONS[index % VARIANT_ICONS.length];

  return (
    <View
      className="bg-md-surface-container-lowest rounded-[20px] p-8 gap-4 border border-md-outline-variant/30"
      style={{
        borderCurve: 'continuous',
        boxShadow: '0 15px 30px rgba(93, 95, 239, 0.08)',
      }}
    >
      <View className="w-12 h-12 rounded-2xl bg-md-primary-container/10 items-center justify-center">
        <MaterialIcons name={icon} size={28} color="#4343d5" />
      </View>

      <View>
        <Text className="font-jakarta-bold text-[22px] font-bold text-md-on-background mb-2">
          {variant.name}
        </Text>
        <Text className="text-[15px] leading-relaxed text-md-on-surface-variant">
          {variant.userContext}
        </Text>
      </View>

      <VariantObjectives objectives={variant.objectives} />
    </View>
  );
}
