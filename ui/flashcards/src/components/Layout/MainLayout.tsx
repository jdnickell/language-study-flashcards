import { Box, Typography } from '@mui/material';
import * as React from 'react';

type MainLayoutProps = {
  children: React.ReactNode;
  title: string;
};

export const MainLayout = ({ title }: MainLayoutProps) => {
  return (
    <>
      <Box>
        <Typography>{title}</Typography>
        <Box>child components</Box>
      </Box>
    </>
  );
};
