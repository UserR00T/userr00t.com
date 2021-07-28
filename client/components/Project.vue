<template>
  <article class="flex flex-col justify-between mt-4 rounded-md shadow dark:shadow-md">
    <a :href="url">
      <h1 class="py-2 mx-4 hero-text lg">
        <span v-show="label">{{ label }}</span>
        <span class="text-theme">{{ name }}</span>
      </h1>

      <p class="mx-4">
        {{ description }}
      </p>
    </a>
    <footer class="flex items-center justify-between py-2 mt-2 border-t">
      <section class="mx-4">
        <UiBadge v-for="(tag, i) in tags" :key="i" class="mr-1">{{ tag }}</UiBadge>
      </section>
      <nuxt-link :to="{ name: 'project-id', params: { id: id } }" class="mx-4 text-sm">View More...</nuxt-link>
    </footer>
  </article>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';

@Component
export default class ProjectComponent extends Vue {
  @Prop()
  readonly label!: string;

  @Prop()
  readonly id!: string;

  @Prop()
  readonly name!: string;

  @Prop()
  readonly description!: string;

  @Prop()
  readonly url!: string;

  @Prop()
  readonly tags!: string[];
}
</script>