import { axios } from '../../../lib/axios'

import { Category } from '../types';

export const getCategories = (): Promise<Category[]> => {
  return axios.get(`/categories`);
};
