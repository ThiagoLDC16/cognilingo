import { Text, View } from 'react-native';

import { signOut } from '@/features/auth/store/auth-actions';
import { useAuthStore } from '@/features/auth/store/auth-store';
import { AppButton } from '@/shared/components/app-button';
import { Screen } from '@/shared/components/screen';

export default function HomeScreen() {
  const user = useAuthStore((state) => state.user);

  return (
    <Screen contentClassName="justify-between">
      <View className="gap-4">
        <View className="gap-3 rounded-3xl bg-white p-6 shadow-card">
          <Text className="text-sm font-medium uppercase tracking-[2px] text-brand-700">
            Cognilingo
          </Text>
          <Text className="text-3xl font-bold text-slate-950">
            {user?.name ? `Olá, ${user.name}` : 'Sessão autenticada'}
          </Text>
          <Text className="text-base leading-6 text-slate-600">
            A área autenticada já está protegida pelo Expo Router e usa persistência local com
            refresh automático de token.
          </Text>
        </View>

        <View className="rounded-3xl border border-slate-200 bg-slate-100 p-6">
          <Text className="text-sm font-semibold text-slate-900">Usuário carregado</Text>
          <Text className="mt-2 text-sm leading-6 text-slate-600">
            {user
              ? `${user.id} • ${user.name}`
              : 'O endpoint /api/auth/logged-user ainda não existe. Quando estiver disponível, o app preencherá o usuário automaticamente.'}
          </Text>
        </View>
      </View>

      <AppButton title="Sair" variant="secondary" onPress={() => void signOut()} />
    </Screen>
  );
}
