import { Box, Typography } from '@mui/material';
import * as React from 'react';

type MainLayoutProps = {
  children: React.ReactNode;
};

export const MainLayout = ({ children }: MainLayoutProps) => {
  return (
    <>
      <Box>
        <Box>
          <Typography>{children}</Typography>
        </Box>
      </Box>
    </>
  );
};
