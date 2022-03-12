<template>
  <section class="grid grid-cols-1 gap-4 md:grid-cols-3">
    <a :href="contact.url" class="rounded-lg shadow hover:shadow-md dark:bg-gray-700 dark:hover:shadow-lg" rel="noreferrer noopener" v-for="(contact, i) in contacts" :key="i">
      <div class="px-4 py-5 sm:p-6">
        <dt class="text-sm font-medium text-gray-500 truncate dark:text-gray-200">
          {{ contact.name }} <UiBadge v-for="(tag, j) in contact.tags" :key="j" class="mr-1">{{ tag }}</UiBadge>
        </dt>
        <dd class="mt-1 font-semibold text-gray-700 dark:text-gray-300">{{ contact.value }}</dd>
      </div>
    </a>
  </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  async asyncData({ $axios }) {
    const contacts = await $axios.$get('contact');
    return { contacts };
  },
})
export default class IndexContacts extends Vue {}
</script>