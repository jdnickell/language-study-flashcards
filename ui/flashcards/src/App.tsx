import * as React from 'react';
import type { RootState } from './stores/store';
import useMediaQuery from '@mui/material/useMediaQuery';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { AppRoutes } from '../src/routes';

import { AppProvider } from './providers/app';
import { useSelector } from 'react-redux';

function App() {
  const toggleTheme = useSelector((state: RootState) => state.app.Theme);
  const prefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)');
  const isDarkMode =
    (prefersDarkMode && !toggleTheme.value) || (!prefersDarkMode && toggleTheme.value);

  const theme = React.useMemo(
    () =>
      createTheme({
        palette: {
          mode: isDarkMode ? 'dark' : 'light',
        },
      }),
    [prefersDarkMode, toggleTheme]
  );

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <AppProvider>
        <AppRoutes />
      </AppProvider>
    </ThemeProvider>
  );
}

export default App;
