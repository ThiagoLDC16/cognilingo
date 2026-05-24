import { useMemo, useState } from 'react';
import { FlatList, Text, TextInput, TouchableOpacity, View } from 'react-native';

import type { Language } from '../api/onboarding-api/types';

interface LanguagePickerProps {
  languages: Language[];
  selected: string | null;
  onSelect: (code: string) => void;
}

export function LanguagePicker({ languages, selected, onSelect }: LanguagePickerProps) {
  const [query, setQuery] = useState('');

  const filtered = useMemo(
    () =>
      languages.filter((l) => l.name.toLowerCase().includes(query.toLowerCase())),
    [languages, query],
  );

  return (
    <View className="flex-1">
      <View className="flex-row items-center bg-slate-100 rounded-xl px-3 mb-3 h-11">
        <Text className="text-slate-400 mr-2 text-base">🔍</Text>
        <TextInput
          value={query}
          onChangeText={setQuery}
          placeholder="Buscar idioma..."
          placeholderTextColor="#94a3b8"
          className="flex-1 text-slate-900 text-base"
        />
      </View>

      <FlatList
        data={filtered}
        keyExtractor={(item) => item.code}
        renderItem={({ item }) => {
          const isSelected = item.code === selected;
          return (
            <TouchableOpacity
              onPress={() => onSelect(item.code)}
              activeOpacity={0.7}
              className={`flex-row items-center px-4 py-3 rounded-xl mb-2 ${
                isSelected ? 'bg-blue-50 border border-blue-300' : 'bg-white border border-slate-100'
              }`}
            >
              <Text className="text-2xl mr-3">{item.flagEmoji}</Text>
              <Text
                className={`text-base ${isSelected ? 'text-blue-700 font-semibold' : 'text-slate-800'}`}
              >
                {item.name}
              </Text>
            </TouchableOpacity>
          );
        }}
        showsVerticalScrollIndicator={false}
      />
    </View>
  );
}
