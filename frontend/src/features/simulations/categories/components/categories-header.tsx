import { useTranslation } from 'react-i18next';
import { Text, View } from 'react-native';

export function CategoriesHeader() {
  const { t } = useTranslation();

  return (
    <View className="gap-2 items-center pt-2">
      <Text className="font-jakarta-bold text-[32px] leading-[38px] font-bold text-md-primary text-center">
        {t('categories.heading')}
      </Text>
      <Text className="text-lg leading-[29px] text-md-on-surface-variant text-center">
        {t('categories.subtitle')}
      </Text>
    </View>
  );
}
