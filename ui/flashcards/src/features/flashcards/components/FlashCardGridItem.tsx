import {
  Button,
  Box,
  Card,
  CardActionArea,
  CardActions,
  CardContent,
  Grid,
  Typography,
  Stack,
} from '@mui/material';
import DeleteTwoToneIcon from '@mui/icons-material/DeleteTwoTone';
import EditTwoToneIcon from '@mui/icons-material/EditTwoTone';
import StarIcon from '@mui/icons-material/Star';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import { useState } from 'react';
import { Flashcard } from '../types';

type FlashCardGridItemProps = {
  flashcard: Flashcard;
};

export const FlashCardGridItem = ({ flashcard }: FlashCardGridItemProps) => {
  const [isBack, setIsBack] = useState(false);

  return (
    <Grid item xs={12} sm={6} md={4} lg={3}>
      <Card variant="outlined">
        <CardActionArea onClick={() => setIsBack(!isBack)}>
          <CardContent>
            {flashcard.title && (
              <Typography py={1} align="center" variant="body2">
                {flashcard.title}
              </Typography>
            )}
            <Box
              sx={{
                minHeight: '100px',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
              }}
            >
              <Typography align="center" variant="body1">
                {isBack ? flashcard.back : flashcard.front}
              </Typography>
            </Box>
          </CardContent>
        </CardActionArea>
        <Stack direction="row" justifyContent="space-between" alignItems="center" p={1} spacing={2}>
          <Button size="small">
            <DeleteTwoToneIcon />
          </Button>
          <Button size="small">
            <EditTwoToneIcon />
          </Button>
          <Button size="small">{flashcard.id % 3 === 0 ? <StarIcon /> : <StarBorderIcon />}</Button>
        </Stack>
      </Card>
    </Grid>
  );
};
