import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { Pressable, Text, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import { MessageFeedbackClassification, type MessageFeedback } from '@/features/simulations/api/simulations-api/types';

interface GrammarTipProps {
  feedback: MessageFeedback;
  originalContent: string;
  children: React.ReactNode;
}

type DiffSegment = { type: 'keep' | 'remove' | 'add'; text: string };

function diffWords(original: string, corrected: string): DiffSegment[] {
  const a = original.trim().split(/\s+/);
  const b = corrected.trim().split(/\s+/);
  const m = a.length, n = b.length;
  const dp = Array.from({ length: m + 1 }, () => new Array(n + 1).fill(0));
  for (let i = 1; i <= m; i++)
    for (let j = 1; j <= n; j++)
      dp[i][j] = a[i - 1] === b[j - 1] ? dp[i - 1][j - 1] + 1 : Math.max(dp[i - 1][j], dp[i][j - 1]);

  const result: DiffSegment[] = [];
  let i = m, j = n;
  while (i > 0 || j > 0) {
    if (i > 0 && j > 0 && a[i - 1] === b[j - 1]) {
      result.unshift({ type: 'keep', text: a[i - 1] });
      i--; j--;
    } else if (j > 0 && (i === 0 || dp[i][j - 1] >= dp[i - 1][j])) {
      result.unshift({ type: 'add', text: b[j - 1] });
      j--;
    } else {
      result.unshift({ type: 'remove', text: a[i - 1] });
      i--;
    }
  }
  return result;
}

type FeedbackConfig = {
  badge: React.ReactNode;
  badgeBg: string;
  cardBorder: string;
  correctionColor: string;
};

function getFeedbackConfig(classification: MessageFeedbackClassification): FeedbackConfig {
  if (classification === MessageFeedbackClassification.Correct) {
    return {
      badge: <Ionicons name="checkmark" size={14} color="#ffffff" />,
      badgeBg: '#16a34a',
      cardBorder: 'rgba(22, 163, 74, 0.2)',
      correctionColor: '#16a34a',
    };
  }
  if (classification === MessageFeedbackClassification.Context) {
    return {
      badge: <Ionicons name="information" size={16} color="#ffffff" />,
      badgeBg: '#60a5fa',
      cardBorder: 'rgba(96, 165, 250, 0.3)',
      correctionColor: '#3b82f6',
    };
  }
  return {
    badge: <Ionicons name="alert" size={14} color="#ffffff" />,
    badgeBg: '#ea580c',
    cardBorder: 'rgba(234, 88, 12, 0.2)',
    correctionColor: '#ea580c',
  };
}

function isWarning(classification: MessageFeedbackClassification) {
  return (
    classification === MessageFeedbackClassification.Grammar ||
    classification === MessageFeedbackClassification.Vocabulary ||
    classification === MessageFeedbackClassification.Spelling
  );
}

function GrammarTipBadge({ config, onPress }: { config: FeedbackConfig; onPress?: () => void }) {
  return (
    <Pressable
      onPress={onPress}
      className="absolute -left-8 top-1/2 -translate-y-1/2 w-6 h-6 rounded-full items-center justify-center"
      style={{ backgroundColor: config.badgeBg }}
    >
      {config.badge}
    </Pressable>
  );
}

function GrammarTipCard({
  feedback,
  originalContent,
  config,
}: Omit<GrammarTipProps, 'children'> & { config: FeedbackConfig }) {
  const { t } = useTranslation();
  const segments = feedback.correction ? diffWords(originalContent, feedback.correction) : null;

  return (
    <View
      className="bg-md-surface-container-low rounded-lg p-3 mt-1 max-w-[250px]"
      style={{ borderWidth: 1, borderColor: config.cardBorder, borderCurve: 'continuous' }}
    >
      <Text className="text-xs text-md-on-surface-variant mb-1">
        {t('simulation.grammarTip')}
      </Text>
      {segments ? (
        <Text className="text-base text-md-on-surface">
          {segments.map((seg, idx) => (
            <Text key={idx}>
              {idx > 0 && ' '}
              {seg.type === 'remove' ? (
                <Text className="line-through text-md-outline">{seg.text}</Text>
              ) : seg.type === 'add' ? (
                <Text style={{ color: config.correctionColor }} className="font-medium">{seg.text}</Text>
              ) : (
                seg.text
              )}
            </Text>
          ))}
        </Text>
      ) : (
        <Text className="text-base text-md-on-surface">{feedback.explanation}</Text>
      )}
      {segments && feedback.explanation && (
        <Text className="text-xs text-md-on-surface-variant mt-2">{feedback.explanation}</Text>
      )}
    </View>
  );
}

export function GrammarTip({ feedback, originalContent, children }: GrammarTipProps) {
  const config = getFeedbackConfig(feedback.classification);
  const isCorrect = feedback.classification === MessageFeedbackClassification.Correct;
  const [expanded, setExpanded] = useState(() => isWarning(feedback.classification));

  return (
    <View>
      <View className="relative">
        {children}
        <GrammarTipBadge
          config={config}
          onPress={isCorrect ? undefined : () => setExpanded((prev) => !prev)}
        />
      </View>
      {expanded && !isCorrect && (
        <GrammarTipCard feedback={feedback} originalContent={originalContent} config={config} />
      )}
    </View>
  );
}
