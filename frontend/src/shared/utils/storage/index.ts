import { Platform } from 'react-native';

import { localStorage } from './local-storage';
import { secureStorage } from './secure-storage';

import type { IStorage } from './types';

export const storage: IStorage = Platform.OS === 'web'
    ? localStorage
    : secureStorage;
