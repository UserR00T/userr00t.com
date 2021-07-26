<template>
  <header class="py-8">
    <nav class="flex justify-center h-16 px-4 rounded-lg shadow dark:bg-gray-700 sm:justify-between">
      <div></div>
      <aside class="flex space-x-8">
        <nuxt-link
          :to="link.url"
          v-for="(link, i) in links"
          :key="i"
          class="inline-flex items-center px-1 pt-1 text-sm font-medium text-gray-500 border-b-2 border-transparent hover:border-gray-300 hover:text-gray-700"
        >
          {{ link.name }}
        </nuxt-link>
      </aside>
    </nav>
  </header>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component
export default class LayoutHeader extends Vue {
  links = [
    {
      name: 'userr00t.com',
      url: '/',
    },
    {
      name: 'Projects',
      url: '/projects',
    },
    {
      name: 'Blog',
      url: '/blog',
    },
    {
      name: 'Contact',
      url: '/contact',
    },
  ];

  logout() {
    localStorage.removeItem('token');
    this.$router.push('/');
  }
}
</script>