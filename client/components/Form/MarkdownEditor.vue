<template>
  <section class="relative">
    <UiBadge class="absolute cursor-pointer top-2 right-2" @click.native="toggleRender">{{ renderShown ? 'Show Source' : 'Show Preview' }}</UiBadge>
    <section>
      <section v-html="markdown" v-show="renderShown" style="min-height: 4rem" class="markdown"></section>
      <textarea :readonly="readOnly" v-model="val" @input="$emit('input', val)" v-show="!renderShown" class="w-full focus:outline-none" />
    </section>
  </section>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';
import marked from 'marked';

@Component<MarkdownEditor>({
  created() {
    this.val = this.value;
    if (this.readOnly) {
      this.toggleRender();
    }
  },
})
export default class MarkdownEditor extends Vue {
  renderShown = false;
  val!: any;
  markdown: string = '';

  @Prop()
  readonly value!: any;

  @Prop()
  readonly readOnly!: boolean;

  toggleRender() {
    this.renderShown = !this.renderShown;
    if (!this.renderShown) {
      return;
    }
    this.markdown = marked(this.val);
  }
}
</script>