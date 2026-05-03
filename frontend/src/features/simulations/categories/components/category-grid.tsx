import { View } from 'react-native';

import type { Category } from '@/features/simulations/api/simulations-api/types';
import { CategoryCard } from './category-card';

interface CategoryGridProps {
  categories: Category[];
  onCategoryPress: (category: Category) => void;
}

export function CategoryGrid({ categories, onCategoryPress }: CategoryGridProps) {
  return (
    <View className="flex-row flex-wrap gap-4">
      {categories.map((category) => (
        <CategoryCard
          key={category.id}
          category={category}
          onPress={() => onCategoryPress(category)}
        />
      ))}
    </View>
  );
}
