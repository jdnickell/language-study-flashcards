import { AppRoutes } from '../src/routes';

import { AppProvider } from './providers/app';

function App() {
  return (
    <AppProvider>
      <AppRoutes />
    </AppProvider>
  );
}

export default App;
