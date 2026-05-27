export interface Category {
  id: string;
  icon: string;
  name: string;
  languageCode: string;
}

export interface Situation {
  id: string;
  name: string;
  description: string;
  languageCode: string;
}

export interface Variant {
  id: string;
  name: string;
  userContext: string;
  languageCode: string;
  objectives: string[];
}

export interface MessageFeedback {
  classification: number;
  explanation: string | null;
  correction: string | null;
}

export enum MessageSender {
  AI = 1,
  USER = 2
}

export interface SimulationMessage {
  id: string;
  sender: MessageSender;
  content: string;
  translatedContent: string | null;
  feedback: MessageFeedback | null;
}

export interface TranslateMessageResponse {
  translatedContent: string;
}
