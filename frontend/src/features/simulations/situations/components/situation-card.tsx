import { MaterialIcons } from '@expo/vector-icons';
import { Pressable, Text, View } from 'react-native';

import type { Situation } from '@/features/simulations/api/simulations-api/types';

// TODO: Replace with the appropriate icons from the API
const SITUATION_ICON_MAP: Record<string, keyof typeof MaterialIcons.glyphMap> = {
  airport: 'flight-takeoff',
  flight: 'flight-takeoff',
  hotel: 'hotel',
  booking: 'hotel',
  directions: 'directions',
  taxi: 'local-taxi',
  restaurant: 'restaurant',
  shopping: 'shopping-cart',
  hospital: 'local-hospital',
  pharmacy: 'local-pharmacy',
  bank: 'account-balance',
  museum: 'museum',
  beach: 'beach-access',
  train: 'train',
  bus: 'directions-bus',
  school: 'school',
  office: 'work',
  park: 'park',
  market: 'storefront',
  cinema: 'movie',
};

function getSituationIcon(name: string): keyof typeof MaterialIcons.glyphMap {
  const lowerName = name.toLowerCase();
  for (const [keyword, icon] of Object.entries(SITUATION_ICON_MAP)) {
    if (lowerName.includes(keyword)) return icon;
  }
  return 'chat-bubble-outline';
}

interface SituationCardProps {
  situation: Situation;
  onPress: () => void;
}

export function SituationCard({ situation, onPress }: SituationCardProps) {
  const icon = getSituationIcon(situation.name);

  return (
    <Pressable
      onPress={onPress}
      className="bg-md-surface-container-lowest rounded-[20px] p-4 shadow-md-1 active:scale-[0.98]"
      style={{ borderCurve: 'continuous' }}
    >
      <View className="flex-row items-center gap-4">
        <View className="w-12 h-12 rounded-full bg-md-primary-fixed items-center justify-center">
          <MaterialIcons name={icon} size={24} color="#4343d5" />
        </View>
        <View className="flex-1">
          <Text className="font-jakarta-bold text-lg font-bold text-md-on-surface">
            {situation.name}
          </Text>
          <Text className="text-xs text-md-on-surface-variant mt-1" numberOfLines={2}>
            {situation.description}
          </Text>
        </View>
        <MaterialIcons name="chevron-right" size={24} color="#767586" />
      </View>
    </Pressable>
  );
}
