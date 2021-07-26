import { Plugin } from '@nuxt/types';

const plugin: Plugin = (_, inject) => {
  inject('loggedIn', () => {
    return localStorage.getItem('token') !== null;
  });
};
export default plugin;
