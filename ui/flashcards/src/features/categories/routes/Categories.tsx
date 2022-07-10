import { Box } from '@mui/material';
import { useEffect, useState } from 'react';
import { Head } from '../../../components/Head';

import { ContentLayout } from '../../../components/Layout';
import { getCategories } from '../api/getCategories';

import { Category } from '../types';

export const Categories = () => {
  const [categories, setCategories] = useState<Category[]>([]);

  useEffect(() => {
    getCategories().then((categoriesResult) => {
      setCategories(categoriesResult);
    });
  }, []);

  return (
    <>
      <Head title={'Categories'} description={'All'} />
      <ContentLayout title="Categories">
        {categories.map((category, index) => {
          return <Box key={index}>{category.name}</Box>;
        })}
      </ContentLayout>
    </>
  );
};
