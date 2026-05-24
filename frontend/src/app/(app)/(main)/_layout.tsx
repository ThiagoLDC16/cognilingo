import { DrawerContentScrollView, DrawerItemList } from '@react-navigation/drawer';
import type { DrawerContentComponentProps } from '@react-navigation/drawer';
import { View } from 'react-native';
import { Drawer } from 'expo-router/drawer';
import { useTranslation } from 'react-i18next';

import { LogoutButton } from '@/features/auth/components/LogoutButton';

const AppDrawerContent = (props: DrawerContentComponentProps) => (
  <DrawerContentScrollView {...props} contentContainerStyle={{ flex: 1 }}>
    <View className="flex-1">
      <DrawerItemList {...props} />
    </View>
    <LogoutButton />
  </DrawerContentScrollView>
);

export default function MainLayout() {
  const { t } = useTranslation();

  return (
    <Drawer
      drawerContent={(props) => <AppDrawerContent {...props} />}
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
