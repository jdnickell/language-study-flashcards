import { useRoutes } from 'react-router-dom';

import { Landing } from '../features/misc';

import { protectedRoutes } from './protected';

//import { useAuth } from '@/lib/auth';
//import { publicRoutes } from './public';

export const AppRoutes = () => {
  //const auth = useAuth();

  const commonRoutes = [{ path: '/', element: <Landing /> }];

  //const routes = auth.user ? protectedRoutes : publicRoutes;
  const routes = protectedRoutes;

  const element = useRoutes([...routes, ...commonRoutes]);

  return <>{element}</>;
};
