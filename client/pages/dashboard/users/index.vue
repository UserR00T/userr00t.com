<template>
  <article class="pb-2 mx-auto rounded-md shadow lg:w-3/4">
    <UiTable :entities="users" :headers="['id', 'username']" type="users" />
  </article>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const users = await $axios.$get('user');
    return { users };
  },
})
export default class IndexUsers extends Vue {}
</script>