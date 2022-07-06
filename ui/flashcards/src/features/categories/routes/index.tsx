import { Navigate, Route, Routes } from 'react-router-dom';

import { Categories } from './Categories';

export const CategoriesRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<Categories />} />
      {/* <Route path=":categoryId" element={<Category />} /> */}
      <Route path="*" element={<Navigate to="." />} />
    </Routes>
  );
};
