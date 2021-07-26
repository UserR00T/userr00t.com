import { Plugin } from '@nuxt/types';
import { AxiosError } from 'axios';
import Vue from 'vue';
import https from 'https';

const plugin: Plugin = ({ $axios, app, redirect }) => {
  $axios.defaults.httpsAgent = new https.Agent({ rejectUnauthorized: false });

  $axios.onResponse((response) => {
    // Update or create data request
    if (response.config.method === 'put' || response.config.method === 'post') {
      Vue.notify({
        type: 'success',
        title: `Changes saved!`,
        text: `Your changes were saved.`,
      });
    }

    if (response.config.method === 'delete' && response.status === 204) {
      Vue.notify({
        type: 'warn',
        title: `Entity deleted`,
        text: `The requested entity has been removed.`,
      });
    }
  });
  $axios.interceptors.request.use((request) => {
    const token = localStorage.getItem('token');
    request.headers['Authorization'] = token ? `Bearer ${token}` : null;
    return request;
  });
  $axios.interceptors.response.use(
    (response) => {
      return response;
    },
    (error: AxiosError<any>) => {
      const { response } = error;

      // If the server returns a bad request (client issue), show a notification.
      if (response?.status === 400) {
        Vue.notify({
          type: 'error',
          title: response.data.title,
          text: Object.keys(response.data.errors)
            .map((key) => response.data.errors[key])
            .flat()
            .join('\n'),
        });
        return Promise.resolve({ data: undefined });
      }

      // If the server returns a Unauthorized (most likely expired/invalid JWT token) result, redirect to login.
      if (response?.status === 401) {
        const currentRoute = app.router?.currentRoute;
        if (!currentRoute || currentRoute.path.startsWith('/auth/')) {
          return Promise.reject(error);
        }
        redirect(`/auth/login?t=${currentRoute.path}`);
        return Promise.resolve();
      }

      return Promise.reject(error);
    }
  );
};
export default plugin;
