import { ScrollView, View } from 'react-native';
import { SafeAreaView } from 'react-native-safe-area-context';

import { cn } from '@/shared/utils/cn';

import type { PropsWithChildren } from 'react';

interface ScreenProps extends PropsWithChildren {
  contentClassName?: string;
}

export function Screen({ children, contentClassName }: ScreenProps) {
  return (
    <SafeAreaView className="flex-1 bg-slate-50">
      <ScrollView
        bounces={false}
        contentContainerStyle={{ flexGrow: 1 }}
        keyboardShouldPersistTaps="handled"
        showsVerticalScrollIndicator={false}>
        <View className={cn('min-h-full flex-grow px-6 py-8', contentClassName)}>{children}</View>
      </ScrollView>
    </SafeAreaView>
  );
}
