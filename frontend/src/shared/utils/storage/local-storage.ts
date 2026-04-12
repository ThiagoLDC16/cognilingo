import type { IStorage } from './types';

export const localStorage: IStorage = {
  getItem: async (key: string) => {
    return window.localStorage.getItem(key);
  },
  setItem: async (key: string, value: string) => {
    window.localStorage.setItem(key, value);
  },
  removeItem: async (key: string) => {
    window.localStorage.removeItem(key);
  },
};
