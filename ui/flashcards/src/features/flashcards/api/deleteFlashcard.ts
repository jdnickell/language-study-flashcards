import { axios } from '../../../lib/axios'

export const deleteFlashcard = ({ id }: { id: number }) => {
    return axios.delete(`/flashcards/${id}`);
  };