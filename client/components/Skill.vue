<template>
  <article class="my-4 rounded-md shadow dark:shadow-md">
    <h1 class="py-2 mx-4 hero-text lg">
      <span>Skills</span>
      <span class="text-theme">{{ name }}</span>
    </h1>
    <section class="pb-2 mx-4">
      <UiSlider v-for="(skill, i) in skills" :key="i" :name="skill.name" :value="skill.value" />
    </section>
  </article>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';

@Component
export default class SkillComponent extends Vue {
  @Prop(String)
  readonly name!: String;

  @Prop(Array)
  readonly skills!: Array<any>;
}
</script>