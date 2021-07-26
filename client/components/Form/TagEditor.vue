<template>
  <ul class="flex overflow-x-auto">
    <li v-for="(tag, i) in val" :key="i" class="pr-1">
      <UiBadge>
        {{ tag }}
        <span @click="removeTag(i)" class="my-auto">
          <SvgX />
        </span>
      </UiBadge>
    </li>
    <li class="flex-1 ml-1">
      <input type="text" v-model="newTag" class="w-full focus:outline-none" @keydown.space.prevent="addTag" @keydown.enter.prevent="addTag" />
    </li>
  </ul>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';

@Component<TagEditor>({
  created() {
    this.val = this.value || [];
  },
})
export default class TagEditor extends Vue {
  val: string[] = [];
  newTag: string = '';

  @Prop()
  readonly value!: any;

  addTag() {
    if (!this.newTag) {
      return;
    }
    this.val.push(this.newTag);
    this.newTag = '';
    this.$emit('input', this.val);
  }

  removeTag(index: number) {
    this.$delete(this.val, index);
    this.$emit('input', this.val);
  }
}
</script>