<template>
  <article class="pb-2 mx-auto rounded-md shadow lg:w-3/4">
    <UiTable :entities="contacts" :headers="['name', 'value', 'tags']" type="contacts">
      <template #row-value="{ entity }">
        <a :href="entity.url" rel="noreferrer noopener" class="text-red-500">{{ entity.value }}</a>
      </template>
      <template #row-tags="{ entity }">
        <UiBadge v-for="(tag, i) in entity.tags" :key="i" class="mr-1">
          {{ tag }}
        </UiBadge>
      </template>
    </UiTable>
  </article>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const contacts = await $axios.$get('contact');
    return { contacts };
  },
})
export default class IndexContacts extends Vue {}
</script>