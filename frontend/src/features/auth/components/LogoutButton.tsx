import { useState } from 'react';
import { Pressable, Text } from 'react-native';
import { useTranslation } from 'react-i18next';
import { useRouter } from 'expo-router';
import { Ionicons } from '@expo/vector-icons';

import { authApi } from '@/features/auth/api/auth-api';
import { authStore } from '@/features/auth/store/auth-store';
import { ConfirmationModal } from '@/shared/components/ConfirmationModal';

export const LogoutButton = () => {
  const { t } = useTranslation();
  const router = useRouter();
  const [dialogVisible, setDialogVisible] = useState(false);
  const logout = authStore((state) => state.logout);
  const refreshToken = authStore((state) => state.refreshToken);

  const handleConfirm = async () => {
    setDialogVisible(false);
    if (refreshToken) {
      await authApi.logout({ refreshToken }).catch(() => {});
    }
    logout();
    router.replace('/(auth)/login');
  };

  return (
    <>
      <Pressable
        className="flex-row items-center px-4 py-3 gap-3 active:bg-slate-100"
        onPress={() => setDialogVisible(true)}
      >
        <Ionicons name="log-out-outline" size={22} color="#ef4444" />
        <Text className="text-base font-medium text-red-500">{t('sidebar.logout')}</Text>
      </Pressable>
      <ConfirmationModal
        visible={dialogVisible}
        title={t('logout.dialog.title')}
        message={t('logout.dialog.message')}
        confirmLabel={t('logout.dialog.confirm')}
        cancelLabel={t('logout.dialog.cancel')}
        onConfirm={handleConfirm}
        onCancel={() => setDialogVisible(false)}
        destructive
      />
    </>
  );
};
