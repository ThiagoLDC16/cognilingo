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
}

export interface MessageFeedback {
  classification: number;
  explanation: string | null;
  correction: string | null;
}

export interface SimulationMessage {
  id: string;
  sender: number;
  content: string;
  translatedContent: string | null;
  feedback: MessageFeedback | null;
}
