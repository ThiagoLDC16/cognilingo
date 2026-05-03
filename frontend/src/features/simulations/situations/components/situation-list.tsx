import { View } from 'react-native';

import type { Situation } from '@/features/simulations/api/simulations-api/types';
import { SituationCard } from './situation-card';

interface SituationListProps {
  situations: Situation[];
  onSituationPress: (situation: Situation) => void;
}

export function SituationList({ situations, onSituationPress }: SituationListProps) {
  return (
    <View className="gap-4">
      {situations.map((situation) => (
        <SituationCard
          key={situation.id}
          situation={situation}
          onPress={() => onSituationPress(situation)}
        />
      ))}
    </View>
  );
}
