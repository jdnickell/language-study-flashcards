import { Typography } from '@mui/material';
import { ContentLayout } from '../../../components/Layout';
import { Box } from '@mui/system';

export const Dashboard = () => {
  return (
    <ContentLayout title="Dashboard">
      <Box>
        <Typography variant="h5">Dashboard</Typography>
      </Box>
    </ContentLayout>
  );
};
