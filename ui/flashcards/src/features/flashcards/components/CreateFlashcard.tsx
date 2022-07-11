import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
} from '@mui/material';

import AddCircleOutlineTwoToneIcon from '@mui/icons-material/AddCircleOutlineTwoTone';
import { useState } from 'react';
import { createFlashcard } from '../api/createFlashcard';

export const CreateFlashcard = () => {
  const initialDataState = { title: '', front: '', back: '', categoryId: 5 };

  const [data, setData] = useState(initialDataState);
  const [isOpen, setIsOpen] = useState(false);

  async function handleCreateFlashCard() {
    let newFlashcard = await createFlashcard({
      data: data,
    });
    setIsOpen(false);
  }

  function handleOpen() {
    setData(initialDataState);
    setIsOpen(true);
  }

  return (
    <>
      <Box p={2} sx={{ display: 'flex', justifyContent: 'center' }}>
        <Button variant="outlined" startIcon={<AddCircleOutlineTwoToneIcon />} onClick={handleOpen}>
          Create Flashcard
        </Button>
      </Box>

      <Dialog open={isOpen} onClose={() => setIsOpen(false)}>
        <DialogTitle>Create Flashcard</DialogTitle>
        <DialogContent>
          <TextField
            margin="dense"
            id="title"
            label="Title (optional)"
            type="text"
            fullWidth
            variant="standard"
            value={data.title}
            onChange={(event) => setData({ ...data, title: event.target.value })}
          />
          <TextField
            autoFocus
            margin="dense"
            id="front"
            label="Front"
            type="text"
            fullWidth
            variant="standard"
            value={data.front}
            onChange={(event) => setData({ ...data, front: event.target.value })}
          />
          <TextField
            multiline
            rows={4}
            margin="dense"
            id="back"
            label="Back"
            type="text"
            fullWidth
            variant="standard"
            value={data.back}
            onChange={(event) => setData({ ...data, back: event.target.value })}
          />
        </DialogContent>
        <DialogActions>
          <Button color="inherit" onClick={() => setIsOpen(false)}>
            Cancel
          </Button>
          <Button color="primary" variant="contained" onClick={handleCreateFlashCard}>
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
