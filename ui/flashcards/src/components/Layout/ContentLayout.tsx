import { Box, Container, Typography } from '@mui/material';
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
      <Container fixed>
        <Typography py={3} variant="h5">
          {title}
        </Typography>
        <Box py={3}>{children}</Box>
      </Container>
    </>
  );
};
