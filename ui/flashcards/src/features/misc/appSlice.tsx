import { createSlice } from '@reduxjs/toolkit';

export interface ToggleThemeState {
  value: boolean;
}

export interface AppState {
  Theme: ToggleThemeState;
}

//global app settings and config info
const initialState: AppState = {
  Theme: { value: false },
};

export const appSlice = createSlice({
  name: 'app',
  initialState,
  reducers: {
    toggleTheme: (state) => {
      state.Theme.value = !state.Theme.value;
    },
  },
});

export const { toggleTheme } = appSlice.actions;

export default appSlice.reducer;
