import { axios } from '../../../lib/axios'

import { Flashcard } from '../types';

export const getFlashcards = (): Promise<Flashcard[]> => {
  return axios.get(`/flashcards`);
};
