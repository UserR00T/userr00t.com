<template>
  <article class="pb-2 mx-auto rounded-md shadow lg:w-3/4">
    <UiTable :entities="configurations" :headers="['key', 'value']" type="configurations">
      <template #row-value="{ entity }">
        {{ entity.value.length > 64 ? `${entity.value.substring(0, 64)}...` : entity.value }}
      </template>
    </UiTable>
  </article>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const configurations = await $axios.$get('configuration');
    return { configurations };
  },
})
export default class IndexConfigurations extends Vue {}
</script>