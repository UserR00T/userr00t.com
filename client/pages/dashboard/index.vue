<template>
  <section>
    <h1 class="hero-text xl">
      <span>{{ $loggedIn() ? 'Change' : 'View' }} Stuff.</span>
      <span class="text-theme">Dashboard</span>
    </h1>
    <section class="flex mt-4">
      <section class="w-3/5 px-4">
        <p>
          Welcome to the dashboard page! Here you can view _most_ defined entities, and with the right permissions edit them. For transparency sake, these pages are open
          to the public. Have a look around!
        </p>
        <p><span class="font-bold">NOTE</span> There is a 2 minute cache on the index "/home" route.</p>
        <p>
          <span class="text-red-400">{{ $loggedIn() ? 'It seems that you are authenticated. Welcome! You may now change and delete any entity.' : '' }}</span>
        </p>
      </section>
      <aside class="w-2/5 px-4">
        <dl class="grid grid-cols-1 gap-5 sm:grid-cols-2">
          <nuxt-link :to="link.url" class="rounded-lg shadow hover:shadow-md dark:shadow-md dark:hover:shadow-lg" v-for="(link, key, i) in links" :key="i">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate dark:text-gray-300">{{ link.name }} <UiBadge v-show="link.authenticated">Authenticated</UiBadge></dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics[key] }}</dd>
            </div>
          </nuxt-link>
        </dl>
      </aside>
    </section>
  </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const metrics = await $axios.$get('home/dashboard');
    return { metrics };
  },
})
export default class IndexDashboard extends Vue {
  links = {
    projects: {
      url: '/dashboard/projects',
      authenticated: false,
      name: 'Projects'
    },
    skills: {
      url: '/dashboard/skills',
      authenticated: false,
      name: 'Skills'
    },
    contacts: {
      url: '/dashboard/contacts',
      authenticated: false,
      name: 'Contacts'
    },
    users: {
      url: '/dashboard/users',
      authenticated: true,
      name: 'Users'
    },
    configurations: {
      url: '/dashboard/configurations',
      authenticated: true,
      name: 'Configurations'
    }
  }
}
</script>