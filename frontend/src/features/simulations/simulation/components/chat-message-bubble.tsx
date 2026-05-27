import { MaterialIcons } from '@expo/vector-icons';
import { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { ActivityIndicator, Pressable, Text, View } from 'react-native';

import { MessageSender, type SimulationMessage } from '@/features/simulations/api/simulations-api/types';
import { GrammarTip } from './grammar-tip';

interface ChatMessageBubbleProps {
  message: SimulationMessage;
  onTranslate: (messageId: string) => Promise<void>;
  isTranslating: boolean;
}

interface MessageActionsProps {
  hasTranslation: boolean;
  showTranslation: boolean;
  isTranslating: boolean;
  onTranslatePress: () => void;
  onToggleTranslation: () => void;
}

function TranslatedContent({ content }: { content: string }) {
  return (
    <Text className="text-sm text-md-outline italic mt-2 border-t border-md-surface-variant pt-2">
      {content}
    </Text>
  );
}

function MessageActions({
  hasTranslation,
  showTranslation,
  isTranslating,
  onTranslatePress,
  onToggleTranslation,
}: MessageActionsProps) {
  const { t } = useTranslation();

  const handleTranslatePress = hasTranslation ? onToggleTranslation : onTranslatePress;

  return (
    <View className="flex-row mt-1 gap-3 pl-1">
      <Pressable
        onPress={handleTranslatePress}
        disabled={isTranslating}
        className="flex-row items-center gap-1"
      >
        {isTranslating ? (
          <ActivityIndicator size={14} color="#767586" />
        ) : (
          <MaterialIcons
            name="translate"
            size={14}
            color={showTranslation ? '#4343d5' : '#767586'}
          />
        )}
        <Text
          className="text-xs"
          style={{ color: showTranslation ? '#4343d5' : '#767586' }}
        >
          {t('simulation.translate')}
        </Text>
      </Pressable>
    </View>
  );
}

function AiBubble({ message, onTranslate, isTranslating }: ChatMessageBubbleProps) {
  const [showTranslation, setShowTranslation] = useState(false);

  const handleTranslatePress = async () => {
    await onTranslate(message.id);
    setShowTranslation(true);
  };

  return (
    <View className="items-start max-w-[85%]">
      <View
        className="bg-md-surface-container-lowest p-4 text-md-on-surface"
        style={{
          borderTopLeftRadius: 20,
          borderTopRightRadius: 20,
          borderBottomRightRadius: 20,
          borderBottomLeftRadius: 4,
          borderCurve: 'continuous',
          boxShadow: '0 4px 15px rgba(93, 95, 239, 0.05)',
        }}
      >
        <Text className="text-base text-md-on-surface">{message.content}</Text>
        {showTranslation && message.translatedContent && (
          <TranslatedContent content={message.translatedContent} />
        )}
      </View>
      <MessageActions
        hasTranslation={message.translatedContent !== null}
        showTranslation={showTranslation}
        isTranslating={isTranslating}
        onTranslatePress={handleTranslatePress}
        onToggleTranslation={() => setShowTranslation((prev) => !prev)}
      />
    </View>
  );
}

function UserBubble({ message }: Pick<ChatMessageBubbleProps, 'message'>) {
  const hasFeedback = message.feedback && message.feedback.classification > 0;

  return (
    <View className="items-end self-end max-w-[85%]">
      <View className="relative">
        <View
          className="bg-md-primary p-4"
          style={{
            borderTopLeftRadius: 20,
            borderTopRightRadius: 20,
            borderBottomLeftRadius: 20,
            borderBottomRightRadius: 4,
            borderCurve: 'continuous',
            boxShadow: '0 4px 15px rgba(93, 95, 239, 0.15)',
          }}
        >
          <Text className="text-base text-md-on-primary">{message.content}</Text>
        </View>
        {hasFeedback && (
          <GrammarTip
            feedback={message.feedback!}
            originalContent={message.content}
          />
        )}
      </View>
    </View>
  );
}

export function ChatMessageBubble({ message, onTranslate, isTranslating }: ChatMessageBubbleProps) {
  if (message.sender === MessageSender.AI) {
    return <AiBubble message={message} onTranslate={onTranslate} isTranslating={isTranslating} />;
  }
  return <UserBubble message={message} />;
}
