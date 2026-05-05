import { Pressable, ScrollView, Text } from 'react-native';

interface SuggestionChipsProps {
  suggestions: string[];
  onSelect: (suggestion: string) => void;
}

export function SuggestionChips({ suggestions, onSelect }: SuggestionChipsProps) {
  if (suggestions.length === 0) return null;

  return (
    <ScrollView
      horizontal
      showsHorizontalScrollIndicator={false}
      contentContainerClassName="gap-2 pb-1"
    >
      {suggestions.map((suggestion) => (
        <Pressable
          key={suggestion}
          onPress={() => onSelect(suggestion)}
          className="bg-md-surface-container px-4 py-2 rounded-full active:bg-md-surface-container-high"
        >
          <Text className="text-xs text-md-on-surface-variant">{suggestion}</Text>
        </Pressable>
      ))}
    </ScrollView>
  );
}
