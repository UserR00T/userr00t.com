<template>
  <section>
    <h1 class="text-4xl font-extrabold tracking-tight text-gray-800 sm:text-5xl md:text-6xl">
      <span class="block xl:inline">{{ $loggedIn() ? 'Change' : 'View' }} Stuff.</span>
      <span class="block text-red-400 xl:inline">Dashboard</span>
    </h1>
    <section class="flex mt-4">
      <section class="w-3/5 px-4 text-gray-800">
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
          <nuxt-link to="/dashboard/projects" class="rounded-lg shadow hover:shadow-md">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate">Projects</dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics.projects }}</dd>
            </div>
          </nuxt-link>

          <nuxt-link to="/dashboard/skills" class="rounded-lg shadow hover:shadow-md">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate">Skills</dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics.skills }}</dd>
            </div>
          </nuxt-link>

          <nuxt-link to="/dashboard/contacts" class="rounded-lg shadow hover:shadow-md">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate">Contacts</dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics.contacts }}</dd>
            </div>
          </nuxt-link>

          <nuxt-link to="/dashboard/users" class="rounded-lg shadow hover:shadow-md">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate">Users <UiBadge>Authenticated</UiBadge></dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics.users }}</dd>
            </div>
          </nuxt-link>

          <nuxt-link to="/dashboard/configurations" class="rounded-lg shadow hover:shadow-md">
            <div class="px-4 py-5 sm:p-6">
              <dt class="text-sm font-medium text-gray-500 truncate">Configurations <UiBadge>Authenticated</UiBadge></dt>
              <dd class="mt-1 text-3xl font-semibold text-red-500">{{ metrics.configurations }}</dd>
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
export default class IndexDashboard extends Vue {}
</script>