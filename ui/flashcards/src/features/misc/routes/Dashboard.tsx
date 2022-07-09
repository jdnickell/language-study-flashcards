import { styled } from '@mui/material/styles';
import { ContentLayout } from '../../../components/Layout';
import { Button, Grid } from '@mui/material';

const DashboardButton = styled(Button)(({ theme }) => ({
  height: '30vh',
  minHeight: '100px',
  width: '100%',
}));

export const Dashboard = () => {
  return (
    <ContentLayout title="Dashboard">
      <Grid container spacing="10">
        <Grid item xs={6}>
          <DashboardButton variant="outlined" color="primary">
            Quick Review
          </DashboardButton>
        </Grid>
        <Grid item xs={6}>
          <DashboardButton variant="outlined" color="primary">
            Categories
          </DashboardButton>
        </Grid>
        <Grid item xs={6}>
          <DashboardButton variant="outlined" color="primary">
            Decks
          </DashboardButton>
        </Grid>
        <Grid item xs={6}>
          <DashboardButton variant="outlined" color="primary">
            Flashcards
          </DashboardButton>
        </Grid>
      </Grid>
    </ContentLayout>
  );
};
