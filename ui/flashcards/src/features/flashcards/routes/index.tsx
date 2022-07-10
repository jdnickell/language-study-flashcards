import { Navigate, Route, Routes } from 'react-router-dom';

import { Flashcards } from './Flashcards';

export const FlashcardsRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<Flashcards />} />
      <Route path="*" element={<Navigate to="." />} />
    </Routes>
  );
};
