import { isAxiosError } from 'axios';

interface ApiErrorResponse {
  errors?: string[];
}

export function getApiErrorMessage(error: unknown, fallbackMessage: string) {
  if (isAxiosError<ApiErrorResponse>(error)) {
    const errors = error.response?.data?.errors;

    if (errors?.length) {
      return errors[0];
    }

    if (error.response?.status === 401) {
      return 'Credenciais inválidas.';
    }
  }

  return fallbackMessage;
}
