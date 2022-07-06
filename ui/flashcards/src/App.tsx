import { ThemeProvider } from '@emotion/react';
import { AppRoutes } from '../src/routes';

import { AppProvider } from './providers/app';
import theme from './theme';
debugger;
const routeXs = <AppRoutes />;
function App() {
  return (
    <ThemeProvider theme={theme}>
      <AppProvider>
        <AppRoutes />
      </AppProvider>
    </ThemeProvider>
  );
}

export default App;
