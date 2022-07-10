import { styled } from '@mui/material/styles';
import { ContentLayout } from '../../../components/Layout';
import { Button, Grid } from '@mui/material';
import { Link } from 'react-router-dom';

const DashboardButton = styled(Button)(({ theme }) => ({
  height: '30vh',
  minHeight: '100px',
  width: '100%',
}));

const NoStyleLink = styled(Link)(({ theme }) => ({
  color: 'inherit',
  textDecoration: 'none',
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
          <NoStyleLink key={'Categories'} to={'../categories'}>
            <DashboardButton variant="outlined" color="primary">
              Categories
            </DashboardButton>
          </NoStyleLink>
        </Grid>
        <Grid item xs={6}>
          <DashboardButton variant="outlined" color="primary">
            Decks
          </DashboardButton>
        </Grid>
        <Grid item xs={6}>
          <NoStyleLink key={'Flashcards'} to={'../flashcards'}>
            <DashboardButton variant="outlined" color="primary">
              Flashcards
            </DashboardButton>
          </NoStyleLink>
        </Grid>
      </Grid>
    </ContentLayout>
  );
};
