export interface Language {
  code: string;
  name: string;
  flagEmoji: string;
}

export interface CreateProfilePayload {
  nativeLanguage: string;
  learningLanguage: string;
}
