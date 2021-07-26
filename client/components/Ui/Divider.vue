<template>
  <div class="relative mt-8">
    <header aria-hidden="true" class="absolute inset-0 flex items-center">
      <hr class="w-full border-t border-gray-300" />
    </header>
    <section class="relative flex justify-center">
      <button
        type="button"
        class="
          focus:outline-none
          focus:ring-2 focus:ring-offset-2 focus:ring-red-500
          hover:bg-gray-50
          inline-flex
          items-center
          shadow-sm
          px-4
          py-1.5
          border border-gray-300
          text-sm
          leading-5
          font-medium
          rounded-full
          text-gray-700
          bg-white
        "
        @click="toggleValue"
      >
        <SvgMinus v-show="shown" />
        <SvgPlus v-show="!shown" />

        <span>{{ shown ? btnHide : btnShow }}</span>
      </button>
    </section>
  </div>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';

@Component
export default class UiDividerComponent extends Vue {
  @Prop(Boolean)
  readonly shown!: Boolean;

  @Prop({ type: String, default: 'View More' })
  readonly btnShow!: String;

  @Prop({ type: String, default: 'View Less' })
  readonly btnHide!: String;

  toggleValue() {
    this.$emit('update:shown', !this.shown);
  }
}
</script>