import { type ComponentProps } from 'react';
import { Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { Drawer } from 'expo-router/drawer';
import { useTranslation } from 'react-i18next';

import { LogoutButton } from '@/features/auth/components/LogoutButton';

type DrawerContentProps = Parameters<NonNullable<ComponentProps<typeof Drawer>['drawerContent']>>[0];

const SPACING = 12;

const AppDrawerContent = ({ state, navigation, descriptors }: DrawerContentProps) => {
  const insets = useSafeAreaInsets();

  return (
    <ScrollView
      contentContainerStyle={[
        styles.contentContainer,
        {
          paddingTop: SPACING + insets.top,
          paddingBottom: SPACING + insets.bottom,
          paddingStart: SPACING + insets.left,
          paddingEnd: SPACING + insets.right,
        },
      ]}
      style={styles.scrollView}
    >
      <View className="flex-1">
        {state.routes.map((route, i) => {
          const focused = i === state.index;
          const { title, drawerLabel } = descriptors[route.key].options;
          const label = typeof drawerLabel === 'string' ? drawerLabel : (title ?? route.name);

          return (
            <Pressable
              key={route.key}
              onPress={() => (focused ? navigation.closeDrawer() : navigation.navigate(route.name))}
              className={`flex-row items-center px-4 py-3 rounded-xl my-0.5 ${
                focused ? 'bg-md-surface-container' : 'active:bg-md-surface-container-low'
              }`}
            >
              <Text
                className={`text-sm font-medium ${
                  focused ? 'text-md-on-surface' : 'text-md-on-surface-variant'
                }`}
              >
                {label}
              </Text>
            </Pressable>
          );
        })}
      </View>
      <LogoutButton />
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: { flex: 1 },
  contentContainer: { flex: 1 },
});

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
