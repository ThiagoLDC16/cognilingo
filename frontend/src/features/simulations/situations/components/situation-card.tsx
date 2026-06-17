import { MaterialIcons } from '@expo/vector-icons';
import { Pressable, Text, View } from 'react-native';

import type { Situation } from '@/features/simulations/api/simulations-api/types';

interface SituationCardProps {
  situation: Situation;
  onPress: () => void;
}

export function SituationCard({ situation, onPress }: SituationCardProps) {
  return (
    <Pressable
      onPress={onPress}
      className="bg-md-surface-container-lowest rounded-[20px] p-4 shadow-md-1 active:scale-[0.98]"
      style={{ borderCurve: 'continuous' }}
    >
      <View className="flex-row items-center gap-4">
        {/* <View className="w-12 h-12 rounded-full bg-md-primary-fixed items-center justify-center">
          <MaterialIcons name={icon} size={24} color="#4343d5" />
        </View> */}
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
