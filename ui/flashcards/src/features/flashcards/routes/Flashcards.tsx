import { Box } from '@mui/material';
import { useEffect, useState } from 'react';
import { Head } from '../../../components/Head';

import { ContentLayout } from '../../../components/Layout';
import { getFlashcards } from '../api/getFlashcards';

import { Flashcard } from '../types';

export const Flashcards = () => {
  const [flashcards, setFlashcards] = useState<Flashcard[]>([]);

  useEffect(() => {
    getFlashcards().then((flashcardsResult) => {
      setFlashcards(flashcardsResult);
    });
  }, []);

  return (
    <>
      <Head title={'Flashcards'} description={'All'} />
      <ContentLayout title="Flashcards">
        {flashcards.map((flashcard, index) => {
          return <Box key={index}>{flashcard.title}</Box>;
        })}
      </ContentLayout>
    </>
  );
};
