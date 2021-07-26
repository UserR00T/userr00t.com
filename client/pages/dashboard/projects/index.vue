<template>
  <article class="pb-2 mx-auto rounded-md shadow lg:w-3/4">
    <UiTable :entities="projects" :headers="['name', 'shortDescription', 'tags', 'url']" type="projects">
      <template #row-url="{ entity }">
        <a :href="entity.url" rel="noreferrer noopener" class="text-red-500">{{ entity.url }}</a>
      </template>
      <template #row-tags="{ entity }">
        <UiBadge v-for="(tag, i) in entity.tags" :key="i" class="mr-1">
          {{ tag }}
        </UiBadge>
      </template>
      <template #row-shortDescription="{ entity }">
        {{ entity.shortDescription.length > 128 ? `${entity.shortDescription.substring(0, 128)}...` : entity.shortDescription }}
      </template>
    </UiTable>
  </article>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const projects = await $axios.$get('project');
    return { projects };
  },
})
export default class IndexProjects extends Vue {}
</script>