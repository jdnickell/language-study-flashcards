import { axios } from '../../../lib/axios'

import { Flashcard } from '../types';

export type CreateFlashcardDTO = {
    data:{
        title: string;
        front: string;
        back: string;
        categoryId: number;
    }
}

export const createFlashcard = ({ data }: CreateFlashcardDTO): Promise<Flashcard> => {
  return axios.post(`/flashcards`, data);
};
