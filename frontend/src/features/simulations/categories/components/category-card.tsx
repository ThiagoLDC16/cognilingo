import { MaterialIcons } from '@expo/vector-icons';
import { Pressable, Text, View } from 'react-native';

import type { Category } from '@/features/simulations/api/simulations-api/types';

interface CategoryCardProps {
  category: Category;
  onPress: () => void;
}

export function CategoryCard({ category, onPress }: CategoryCardProps) {
  return (
    <Pressable
      onPress={onPress}
      className="bg-md-surface-container-lowest rounded-[20px] p-4 items-center justify-center gap-2 shadow-md-1 active:scale-95"
      style={{ flexBasis: '47%' }}
    >
      <View className="w-16 h-16 rounded-full bg-md-primary-fixed items-center justify-center">
        <MaterialIcons name={category.icon as keyof typeof MaterialIcons.glyphMap} size={32} color="#4343d5" />
      </View>
      <Text className="text-sm font-medium tracking-wide text-md-on-surface mt-2 text-center">
        {category.name}
      </Text>
    </Pressable>
  );
}
