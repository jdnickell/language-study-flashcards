import { Grid, Typography } from '@mui/material';
import { useEffect, useState } from 'react';
import { Head } from '../../../components/Head';

import { ContentLayout } from '../../../components/Layout';
import { getFlashcards } from '../api/getFlashcards';
import { CreateFlashcard } from '../components/CreateFlashcard';
import { FlashCardGridItem } from '../components/FlashCardGridItem';

import { Flashcard } from '../types';

export const Flashcards = () => {
  const [flashcards, setFlashcards] = useState<Flashcard[]>([]);

  const handleFlashcardAdded = (newFlashcard: Flashcard) => {
    let newFlashcards = [...flashcards, newFlashcard];
    setFlashcards(newFlashcards);
  };

  const handleFlashcardDeleted = (deletedFlashcardId: number) => {
    let undeletedFlashcards = flashcards.filter((x) => x.id !== deletedFlashcardId);
    setFlashcards(undeletedFlashcards);
  };

  useEffect(() => {
    getFlashcards().then((flashcardsResult) => {
      setFlashcards(flashcardsResult);
    });
  }, []);

  return (
    <>
      <Head title={'Flashcards'} description={'All'} />
      <ContentLayout title="Flashcards">
        <CreateFlashcard handleFlashcardAdded={handleFlashcardAdded} />
        {!flashcards?.length && (
          <>
            <Typography py={3} textAlign={'center'}>
              No flashcards found
            </Typography>
          </>
        )}
        <Grid container spacing={2}>
          {flashcards.map((flashcard, index) => {
            return (
              <FlashCardGridItem
                handleFlashcardDeleted={handleFlashcardDeleted}
                key={index}
                flashcard={flashcard}
              />
            );
          })}
        </Grid>
      </ContentLayout>
    </>
  );
};
