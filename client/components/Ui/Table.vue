<template>
  <table class="min-w-full divide-y divide-gray-200">
    <thead class="bg-gray-50">
      <tr>
        <th scope="col" class="px-6 py-3 text-xs font-medium tracking-wider text-left text-gray-500 uppercase" v-for="(header, i) in headers" :key="i">{{ header }}</th>
        <th scope="col" class="px-6 py-3 text-xs font-medium tracking-wider text-right text-gray-500 uppercase">
          <nuxt-link :to="{ name: `dashboard-${type}-edit-id`, params: { id: 'new' } }" class="text-red-600 hover:text-red-900">Add</nuxt-link>
        </th>
      </tr>
    </thead>
    <tbody class="bg-white divide-y divide-gray-200">
      <tr v-for="(entity, i) in entities" :key="i">
        <td class="px-6 py-4 text-sm text-gray-800 whitespace-nowrap" v-for="(header, j) in headers" :key="j">
          <slot :name="'row-' + header" :entity="entity">
            {{ entity[header] }}
          </slot>
        </td>
        <td class="px-6 py-4 text-sm font-medium text-right whitespace-nowrap">
          <nuxt-link :to="{ name: `dashboard-${type}-edit-id`, params: { id: entity.id } }" class="text-red-600 hover:text-red-900">Edit</nuxt-link>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
  layout: 'dashboard',
  async asyncData({ $axios }) {
    const skills = await $axios.$get('skill');
    return { skills };
  },
})
export default class UiTableComponent extends Vue {
  @Prop()
  readonly entities: any;

  @Prop()
  readonly headers: any;

  @Prop()
  readonly type!: string;
}
</script>