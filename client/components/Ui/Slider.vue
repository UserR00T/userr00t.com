<template>
  <div class="flex items-center justify-between">
    <span class="mr-2" v-show="name">{{ name }}</span>
    <div :class="['relative', name ? 'w-4/5' : 'w-full']">
      <div class="flex h-2 overflow-hidden text-xs bg-red-200 rounded">
        <div :style="{ width: `${value}%` }" class="bg-red-500"></div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';

@Component
export default class UiSliderComponent extends Vue {
  @Prop(String)
  readonly name!: String;

  @Prop(Number)
  readonly value!: Number;
}
</script>