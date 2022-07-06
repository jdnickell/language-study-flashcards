import { Box } from '@mui/material';
import { Head } from '../../../components/Head';

import { ContentLayout } from '../../../components/Layout';

export const Categories = () => {
  return (
    <>
      <Head title={'Categories'} description={'All'} />
      <ContentLayout title="Categories">
        <Box>Categories</Box>
      </ContentLayout>
    </>
  );
};
