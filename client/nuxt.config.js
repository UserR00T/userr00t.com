const baseUrl = process.env.NODE_ENV !== 'development' ? '/' : '/';
const baseApiUrl = process.env.NODE_ENV !== 'development' ? '/api/' : 'https://localhost:5001/api/';

export default {
  // Disable server-side rendering: https://go.nuxtjs.dev/ssr-mode
  ssr: false,

  // Target: https://go.nuxtjs.dev/config-target
  target: 'static',

  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: 'userr00t.com',
    htmlAttrs: {
      lang: 'en',
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'I develop (and mostly break) software.' },

      { hid: 'og:url', property: 'og:url', content: `https://userr00t.com${baseUrl}` },
      { hid: 'og:type', property: 'og:type', content: 'website' },
      { hid: 'og:title', property: 'og:title', content: 'UserR00T' },
      { hid: 'og:description', property: 'og:description', content: 'I develop (and mostly break) software.' },
      { hid: 'og:image', property: 'og:image', content: `https://userr00t.com${baseUrl}embed.png` },
      { hid: 'twitter:card', property: 'twitter:card', content: 'summary_large_image' },
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [
    '~/assets/style.scss',
    '~/assets/markdown.scss',
  ],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [
    '~/plugins/import/formBuilder.js',
    '~/plugins/import/notifications.js',
    '~/plugins/axios.ts',
    '~/plugins/auth.ts',
    '~/plugins/date.ts',
  ],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/typescript
    '@nuxt/typescript-build',
    // https://go.nuxtjs.dev/tailwindcss
    '@nuxtjs/tailwindcss',
  ],

  router: {
    base: baseUrl,
  },

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: ['@nuxtjs/axios'],

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {},

  axios: {
    baseURL: baseApiUrl,
  },
};
