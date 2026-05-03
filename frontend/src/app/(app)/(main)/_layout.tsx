import { Drawer } from 'expo-router/drawer';
import { useTranslation } from 'react-i18next';

export default function MainLayout() {
  const { t } = useTranslation();

  return (
    <Drawer
      screenOptions={{
        headerShadowVisible: false,
        drawerType: 'front',
      }}
    >
      <Drawer.Screen
        name="categories"
        options={{
          title: t('categories.title'),
        }}
      />
    </Drawer>
  );
}
