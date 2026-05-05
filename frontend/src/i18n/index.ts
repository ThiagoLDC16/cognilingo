import * as Localization from 'expo-localization';
import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';

const resources = {
  en: {
    translation: {
      internalError: 'An unexpected error occurred.',
      invalidCredentials: 'Invalid email or password.',
      emailAlreadyInUse: 'This email is already in use.',
      'categories.title': 'Categories',
      'categories.heading': 'Choose a Category',
      'categories.subtitle': 'Practice real-life conversations',
      'simulation.finish': 'Finish',
      'simulation.started': 'Simulation Started',
      'simulation.grammarTip': 'Grammar Tip:',
      'simulation.inputPlaceholder': 'Type your response...',
      'simulation.finishConfirm.title': 'Finish Simulation',
      'simulation.finishConfirm.message': 'Are you sure you want to finish this simulation?',
      'simulation.finishConfirm.cancel': 'Cancel',
      'simulation.finishConfirm.confirm': 'Finish',
      'simulation.completed.title': 'Simulation Completed',
      'simulation.completed.subtitle': 'Excellent effort! Here\'s how you did.',
      'simulation.completed.grammar': 'Grammar',
      'simulation.completed.vocabulary': 'Vocabulary',
      'simulation.completed.fluency': 'Fluency',
      'simulation.completed.nextSimulation': 'Next Simulation',
      'simulation.completed.returnToDashboard': 'Return to Dashboard',
      'variants.subtitle': 'Select a scenario variant to practice.',
      'variants.objectives': 'Objectives',
      'variants.startSimulation': 'Start Simulation',
    },
  },
  pt: {
    translation: {
      internalError: 'Ocorreu um erro inesperado.',
      invalidCredentials: 'Email ou senha inválidos.',
      emailAlreadyInUse: 'Este email já está em uso.',
      'categories.title': 'Categorias',
      'categories.heading': 'Escolha uma Categoria',
      'categories.subtitle': 'Pratique conversas da vida real',
      'simulation.finish': 'Finalizar',
      'simulation.started': 'Simulação Iniciada',
      'simulation.grammarTip': 'Dica Gramatical:',
      'simulation.inputPlaceholder': 'Digite sua resposta...',
      'simulation.finishConfirm.title': 'Finalizar Simulação',
      'simulation.finishConfirm.message': 'Tem certeza que deseja finalizar esta simulação?',
      'simulation.finishConfirm.cancel': 'Cancelar',
      'simulation.finishConfirm.confirm': 'Finalizar',
      'simulation.completed.title': 'Simulação Concluída',
      'simulation.completed.subtitle': 'Excelente esforço! Veja como você se saiu.',
      'simulation.completed.grammar': 'Gramática',
      'simulation.completed.vocabulary': 'Vocabulário',
      'simulation.completed.fluency': 'Fluência',
      'simulation.completed.nextSimulation': 'Próxima Simulação',
      'simulation.completed.returnToDashboard': 'Voltar ao Painel',
      'variants.subtitle': 'Selecione uma variante de cenário para praticar.',
      'variants.objectives': 'Objetivos',
      'variants.startSimulation': 'Iniciar Simulação',
    },
  },
};

i18n.use(initReactI18next).init({
  resources,
  lng: Localization.getLocales()[0]?.languageCode ?? 'en',
  fallbackLng: 'en',
  interpolation: {
    escapeValue: false,
  },
});

export default i18n;
