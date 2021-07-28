<template>
  <section class="w-2/3 mx-auto">
    <header>
      <a :href="project.url">
        <h1 class="text-4xl font-extrabold tracking-tight text-red-400 sm:text-5xl md:text-6xl">
          {{ project.name }}
        </h1>
      </a>
      <section>
        <UiBadge v-for="(tag, i) in project.tags" :key="i" class="mr-1">
          {{ tag }}
        </UiBadge>
      </section>
      <section class="flex flex-col my-2">
        <!-- Small issue while in development, hide if "unset" -->
        <span class="text-sm text-gray-500 dark:text-gray-400" v-show="project.updated !== '0001-01-01T00:00:00+00:00'">
          Updated <span class="font-bold text-gray-700 dark:text-gray-200" :title="$dayjs(project.updated).format()">{{ $dayjs(project.updated).default.fromNow() }}</span> <span class="italic" title="This indicates when this project was last updated on the website, not the actual project content.">(?)</span>
        </span>
        <span class="text-sm text-gray-500 dark:text-gray-400">
          Created <span class="font-bold text-gray-700 dark:text-gray-200" :title="$dayjs(project.created).format()">{{ $dayjs(project.created).default.fromNow() }}</span> <span class="italic" title="This indicates when this project was registered on website, not the actual project creation date.">(?)</span>
        </span>
      </section>
    </header>
    <section>
      <p>{{ project.shortDescription }}</p>
      <FormMarkdownEditor v-model="project.description" :readOnly="true" />
    </section>
  </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  async asyncData({ $axios, params }) {
    const project = await $axios.$get(`project/${params['id']}`);
    project.description ??= '_No description provided._';
    return { project };
  },
})
export default class IdProjects extends Vue {}
</script>