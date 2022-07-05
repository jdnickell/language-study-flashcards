import { Box } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';
import { Suspense } from 'react';
import { Navigate, Outlet } from 'react-router-dom';

import { MainLayout } from '../components/Layout';
import { lazyImport } from '../utils/lazyImport';

// const { Categories } = lazyImport(() => import('../features/categories/index'), 'Categories');
// const { Dashboard } = lazyImport(() => import('@/features/misc'), 'Dashboard');
// const { Profile } = lazyImport(() => import('@/features/users'), 'Profile');
// const { Users } = lazyImport(() => import('@/features/users'), 'Users');

const App = () => {
  return (
    <MainLayout title="Flashcards">
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
      //   { path: '/discussions/*', element: <DiscussionsRoutes /> },
      // { path: '/categories/*', element: <CategoriesRoutes /> },
      //   { path: '/profile', element: <Profile /> },
      //   { path: '/', element: <Dashboard /> },
      { path: '*', element: <Navigate to="." /> },
    ],
  },
];
