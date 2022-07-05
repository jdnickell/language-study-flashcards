import { Box, Typography } from '@mui/material';
import * as React from 'react';

import { Head } from '../Head';

type ContentLayoutProps = {
  children: React.ReactNode;
  title: string;
};

export const ContentLayout = ({ children, title }: ContentLayoutProps) => {
  return (
    <>
      <Head title={title} />
      <Box>
        <Typography variant="h2">{title}</Typography>
        <Box>{children}</Box>
      </Box>
    </>
  );
};
