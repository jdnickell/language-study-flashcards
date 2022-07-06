import { Box } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';
import { Suspense } from 'react';
import { Navigate, Outlet } from 'react-router-dom';

import { MainLayout } from '../components/Layout';
import { lazyImport } from '../utils/lazyImport';

const { CategoriesRoutes } = lazyImport(() => import('../features/categories'), 'CategoriesRoutes');
const { Dashboard } = lazyImport(() => import('../features/misc'), 'Dashboard');

const App = () => {
  return (
    <MainLayout>
      <Suspense
        fallback={
          <Box sx={{ display: 'flex' }}>
            <CircularProgress />
          </Box>
        }
      >
        <Outlet />
      </Suspense>
    </MainLayout>
  );
};

export const protectedRoutes = [
  {
    path: '/app',
    element: <App />,
    children: [
      { path: 'categories/*', element: <CategoriesRoutes /> },
      { path: 'dashboard', element: <Dashboard /> },
      { path: '*', element: <Navigate to="." /> },
    ],
  },
];
