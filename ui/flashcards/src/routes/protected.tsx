import { Box, Typography } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';
import { Suspense } from 'react';
import { Navigate, Outlet } from 'react-router-dom';

import { MainLayout } from '../components/Layout';
import { lazyImport } from '../utils/lazyImport';

const { CategoriesRoutes } = lazyImport(() => import('../features/categories'), 'CategoriesRoutes');
const { FlashcardsRoutes } = lazyImport(() => import('../features/flashcards'), 'FlashcardsRoutes');
const { Dashboard } = lazyImport(() => import('../features/misc'), 'Dashboard');

const App = () => {
  return (
    <>
      <MainLayout>
        <Suspense
          fallback={
            <Box sx={{ display: 'flex' }}>
              <CircularProgress />
            </Box>
          }
        >
          <Outlet />
          <Box display="flex" justifyContent="center" alignItems="center">
            <Typography variant="subtitle2" py={3}>
              Flashcards App
            </Typography>
          </Box>
        </Suspense>
      </MainLayout>
    </>
  );
};

export const protectedRoutes = [
  {
    path: '/app',
    element: <App />,
    children: [
      { path: 'categories/*', element: <CategoriesRoutes /> },
      { path: 'flashcards/*', element: <FlashcardsRoutes /> },
      { path: '', element: <Dashboard /> },
      { path: 'dashboard', element: <Dashboard /> },
      { path: '*', element: <Navigate to="." /> },
    ],
  },
];
