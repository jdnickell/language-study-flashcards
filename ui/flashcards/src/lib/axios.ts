import Axios, { AxiosRequestConfig } from 'axios';

function authRequestInterceptor(config: AxiosRequestConfig) {
  const token = 'getJWTFromCookieOrStorage'//storage.getToken();
  if (token) {
    axios.defaults.headers.common['Authorization'] = `${token}`;
    //config.headers.authorization = `${token}`;
  }
  axios.defaults.headers.common['Accept'] = 'application/json';
  return config;
}

export const axios = Axios.create({
  baseURL: 'https://localhost:7257/api',
});

axios.interceptors.request.use(authRequestInterceptor);
axios.interceptors.response.use(
  (response) => {
    return response.data;
  },
  (error) => {
    const message = error.response?.data?.message || error.message;
    console.log('Api Error:');
    console.log(message);
    alert('Api Error');
    return Promise.reject(error);
  }
);
