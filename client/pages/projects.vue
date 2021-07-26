<template>
  <section class="grid grid-cols-1 gap-4 md:grid-cols-3">
    <Project
      v-for="(project, i) in projects"
      :key="i"
      :id="project.id"
      :name="project.name"
      :description="project.shortDescription"
      :tags="project.tags"
      :url="project.url"
    />
  </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  async asyncData({ $axios }) {
    const projects = await $axios.$get('project');
    return { projects };
  },
})
export default class IndexProjects extends Vue {}
</script>