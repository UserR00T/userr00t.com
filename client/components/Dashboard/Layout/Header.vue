<template>
  <header class="py-8">
    <nav class="flex justify-center h-16 px-4 rounded-lg shadow dark:bg-gray-700 sm:justify-between">
      <div class="flex items-center flex-shrink-0">
        <h2 class="text-sm font-medium text-red-600">Dashboard area</h2>
      </div>
      <aside class="flex space-x-8">
        <nuxt-link
          :to="link.url"
          v-for="(link, i) in links"
          :key="i"
          class="inline-flex items-center px-1 pt-1 text-sm font-medium text-gray-500 border-b-2 border-transparent hover:border-gray-300 hover:text-gray-700"
        >
          {{ link.name }}
        </nuxt-link>
        <span
          @click="logout"
          v-show="$loggedIn()"
          class="inline-flex items-center px-1 pt-1 text-sm font-medium text-red-600 border-b-2 border-transparent cursor-pointer hover:border-red-300 hover:text-red-400"
        >
          Logout
        </span>
      </aside>
    </nav>
  </header>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component
export default class DashboardLayoutHeader extends Vue {
  links = [
    {
      name: 'userr00t.com',
      url: '/',
    },
    {
      name: 'Projects',
      url: '/dashboard/projects',
    },
    {
      name: 'Skills',
      url: '/dashboard/skills',
    },
    {
      name: 'Contacts',
      url: '/dashboard/contacts',
    },
    {
      name: 'Configurations',
      url: '/dashboard/configurations',
    },
    {
      name: 'Users',
      url: '/dashboard/users',
    },
  ];

  logout() {
    localStorage.removeItem('token');
    this.$router.push('/');
  }
}
</script>