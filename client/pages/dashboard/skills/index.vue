<template>
  <article class="pb-2 mx-auto rounded-md shadow lg:w-3/4">
    <UiTable :entities="skills" :headers="['category', 'name', 'value']" type="skills">
      <template #row-value="{ entity }">
        <UiSlider :value="entity.value" />
      </template>
    </UiTable>
  </article>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const skills = await $axios.$get('skill');
    return { skills };
  },
})
export default class IndexSkills extends Vue {}
</script>