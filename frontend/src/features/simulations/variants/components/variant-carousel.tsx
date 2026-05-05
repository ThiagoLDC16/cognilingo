import { ScrollView, useWindowDimensions, View } from 'react-native';

import type { Variant } from '@/features/simulations/api/simulations-api/types';
import { VariantCard } from './variant-card';

interface VariantCarouselProps {
  variants: Variant[];
  onActiveIndexChange: (index: number) => void;
}

const CARD_WIDTH_RATIO = 0.85;
const CARD_GAP = 16;

export function VariantCarousel({ variants, onActiveIndexChange }: VariantCarouselProps) {
  const { width: screenWidth } = useWindowDimensions();
  const cardWidth = screenWidth * CARD_WIDTH_RATIO;
  const sideInset = (screenWidth - cardWidth) / 2;


  const handleScrollEnd = (offsetX: number) => {
    const index = Math.round(offsetX / (cardWidth + CARD_GAP));
    const clampedIndex = Math.max(0, Math.min(index, variants.length - 1));
    onActiveIndexChange(clampedIndex);
  };

  return (
    <ScrollView
      horizontal
      pagingEnabled={false}
      showsHorizontalScrollIndicator={false}
      decelerationRate="fast"
      snapToInterval={cardWidth + CARD_GAP}
      snapToAlignment="center"
      contentContainerStyle={{
        paddingHorizontal: sideInset,
        gap: CARD_GAP,
        paddingVertical: 16,
      }}
      onMomentumScrollEnd={(e) => handleScrollEnd(e.nativeEvent.contentOffset.x)}
    >
      {variants.map((variant, index) => (
        <View key={variant.id} style={{ width: cardWidth }}>
          <VariantCard variant={variant} index={index} />
        </View>
      ))}
    </ScrollView>
  );
}
