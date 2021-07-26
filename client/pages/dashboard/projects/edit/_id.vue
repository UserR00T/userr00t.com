<template>
  <form-builder :form.sync="form" @validated="validated"></form-builder>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { EditEntity, fetchEntity } from '~/mixins/EditEntity';
import MarkdownEditor from '~/components/Form/MarkdownEditor.vue';
import TagEditor from '~/components/Form/TagEditor.vue';

@Component({
  layout: 'dashboard',

  async asyncData(ctx) {
    return await fetchEntity(ctx, 'project');
  },
})
export default class EditProjects extends EditEntity {
  type = 'project';

  inputs() {
    this.form
      .withInput('name', 'text', (x) => x.withLabel('Name').limit(32))
      .withInput('shortDescription', 'text', (x) => x.withLabel('Short Description').limit(256).as('textarea'))
      .withInput('description', 'text', (x) => x.withLabel('Description').limit(2048).as(MarkdownEditor))
      .withInput('url', 'text', (x) => x.withLabel('Url').required(false).limit(64))
      .withInput('tags', 'text', (x) => x.withLabel('Tags').required(false).as(TagEditor));
  }
}
</script>