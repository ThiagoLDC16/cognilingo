import { MaterialIcons } from '@expo/vector-icons';
import { useState } from 'react';
import { Pressable, Text, View } from 'react-native';

import { MessageSender, type SimulationMessage } from '@/features/simulations/api/simulations-api/types';
import { GrammarTip } from './grammar-tip';

interface ChatMessageBubbleProps {
  message: SimulationMessage;
}

function TranslateButton({ onPress }: { onPress: () => void }) {
  return (
    <Pressable
      onPress={onPress}
      className="absolute -right-10 top-1/2 -translate-y-1/2 p-2"
    >
      <MaterialIcons name="translate" size={20} color="#767586" />
    </Pressable>
  );
}

function TranslatedContent({ content }: { content: string }) {
  return (
    <Text className="text-sm text-md-outline italic mt-2 border-t border-md-surface-variant pt-2">
      {content}
    </Text>
  );
}

function AiBubble({ message }: ChatMessageBubbleProps) {
  const [showTranslation, setShowTranslation] = useState(false);

  return (
    <View className="items-start max-w-[85%]">
      <View
        className="bg-md-surface-container-lowest p-4 text-md-on-surface relative"
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
        {message.translatedContent && (
          <TranslateButton onPress={() => setShowTranslation((prev) => !prev)} />
        )}
      </View>
    </View>
  );
}

function UserBubble({ message }: ChatMessageBubbleProps) {
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

export function ChatMessageBubble({ message }: ChatMessageBubbleProps) {
  if (message.sender === MessageSender.AI) {
    return <AiBubble message={message} />;
  }
  return <UserBubble message={message} />;
}
