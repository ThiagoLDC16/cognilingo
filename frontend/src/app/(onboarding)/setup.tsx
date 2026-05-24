import { useRouter } from 'expo-router';
import { useEffect, useState } from 'react';
import { SafeAreaView } from 'react-native-safe-area-context';
import { Text, View } from 'react-native';

import { onboardingApi } from '@/features/onboarding/api/onboarding-api';
import type { Language } from '@/features/onboarding/api/onboarding-api/types';
import { LanguagePicker } from '@/features/onboarding/components/LanguagePicker';
import { authStore } from '@/features/auth/store/auth-store';
import { Button } from '@/shared/components/Button';

const STEPS = [
  { title: 'Qual é o seu idioma nativo?', key: 'native' as const },
  { title: 'Qual idioma você quer praticar?', key: 'learning' as const },
];

export default function SetupScreen() {
  const router = useRouter();
  const [step, setStep] = useState(0);
  const [languages, setLanguages] = useState<Language[]>([]);
  const [nativeLanguage, setNativeLanguage] = useState<string | null>(null);
  const [learningLanguage, setLearningLanguage] = useState<string | null>(null);
  const [isSubmitting, setIsSubmitting] = useState(false);

  useEffect(() => {
    onboardingApi.getLanguages().then(setLanguages);
  }, []);

  const currentStep = STEPS[step];
  const isLastStep = step === STEPS.length - 1;

  const selected = currentStep.key === 'native' ? nativeLanguage : learningLanguage;
  const setSelected = currentStep.key === 'native' ? setNativeLanguage : setLearningLanguage;

  const availableLanguages =
    currentStep.key === 'learning' && nativeLanguage
      ? languages.filter((l) => l.code !== nativeLanguage)
      : languages;

  const handleNext = async () => {
    if (!isLastStep) {
      setStep((s) => s + 1);
      return;
    }

    if (!nativeLanguage || !learningLanguage) return;

    setIsSubmitting(true);
    try {
      await onboardingApi.createProfile({ nativeLanguage, learningLanguage });
      const user = authStore.getState().user;
      if (user) {
        authStore.getState().setUser({ ...user, hasProfile: true });
      }
      router.replace('/(app)/');
    } catch {
      // silent — routing guard will keep user here if needed
    } finally {
      setIsSubmitting(false);
    }
  };

  const handleBack = () => {
    setStep((s) => s - 1);
  };

  return (
    <SafeAreaView className="flex-1 bg-white">
      <View className="flex-1 px-6 pt-10 pb-6">
        {/* Progress */}
        <View className="flex-row gap-2 mb-10">
          {STEPS.map((_, i) => (
            <View
              key={i}
              className={`h-1 flex-1 rounded-full ${i <= step ? 'bg-blue-600' : 'bg-slate-200'}`}
            />
          ))}
        </View>

        {/* Header */}
        <Text className="text-2xl font-bold text-slate-900 mb-1">
          Passo {step + 1} de {STEPS.length}
        </Text>
        <Text className="text-lg text-slate-600 mb-6">{currentStep.title}</Text>

        {/* Language picker */}
        <LanguagePicker
          languages={availableLanguages}
          selected={selected}
          onSelect={setSelected}
        />

        {/* Action */}
        <View className="flex-row gap-3 mt-4">
          <Button
            title="Voltar"
            onPress={handleBack}
            disabled={step === 0}
            className="flex-1"
            variant="secondary"
          />
          <Button
            title={isLastStep ? 'Concluir' : 'Próximo'}
            onPress={handleNext}
            disabled={!selected}
            loading={isSubmitting}
            className="flex-1"
          />
        </View>
      </View>
    </SafeAreaView>
  );
}
