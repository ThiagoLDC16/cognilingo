import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { Pressable, Text, View } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

import type { MessageFeedback } from '@/features/simulations/api/simulations-api/types';

interface GrammarTipProps {
  feedback: MessageFeedback;
  originalContent: string;
}

export function GrammarTipBadge({ onPress }: { onPress: () => void }) {
  return (
    <Pressable
      onPress={onPress}
      className="absolute -left-8 top-1/2 -translate-y-1/2 w-6 h-6 rounded-full bg-md-tertiary-container items-center justify-center border-2 border-md-surface-container-lowest"
      style={{ boxShadow: '0 2px 8px rgba(183, 86, 0, 0.3)' }}
    >
      <MaterialIcons name="lightbulb" size={14} color="#fff6f3" />
    </Pressable>
  );
}

export function GrammarTipCard({ feedback, originalContent }: GrammarTipProps) {
  const { t } = useTranslation();

  return (
    <View
      className="bg-md-surface-container-low rounded-lg p-3 mt-1 max-w-[250px]"
      style={{
        borderWidth: 1,
        borderColor: 'rgba(183, 86, 0, 0.2)',
        borderCurve: 'continuous',
      }}
    >
      <Text className="text-xs text-md-on-surface-variant mb-1">
        {t('simulation.grammarTip')}
      </Text>
      <Text className="text-base text-md-on-surface">
        {feedback.correction && (
          <>
            <Text className="line-through text-md-outline">{originalContent}</Text>
            {'  '}
            <Text className="text-md-tertiary font-medium">{feedback.correction}</Text>
          </>
        )}
        {!feedback.correction && feedback.explanation}
      </Text>
    </View>
  );
}

export function GrammarTip({ feedback, originalContent }: GrammarTipProps) {
  const [expanded, setExpanded] = useState(false);

  return (
    <>
      <GrammarTipBadge onPress={() => setExpanded((prev) => !prev)} />
      {expanded && (
        <GrammarTipCard feedback={feedback} originalContent={originalContent} />
      )}
    </>
  );
}
