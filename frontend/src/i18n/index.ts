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
