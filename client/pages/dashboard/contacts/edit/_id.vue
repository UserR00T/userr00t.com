<template>
  <form-builder :form.sync="form" @validated="validated"></form-builder>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { EditEntity, fetchEntity } from '~/mixins/EditEntity';
import TagEditor from '~/components/Form/TagEditor.vue';

@Component({
  layout: 'dashboard',

  async asyncData(ctx) {
    return await fetchEntity(ctx, 'contact');
  },
})
export default class EditContacts extends EditEntity {
  type = 'contact';

  inputs() {
    this.form
      .withInput('name', 'text', (x) => x.withLabel('Name').limit(16))
      .withInput('value', 'text', (x) => x.withLabel('Value').limit(32))
      .withInput('url', 'text', (x) => x.withLabel('Url').required(false).limit(64))
      .withInput('tags', 'text', (x) => x.withLabel('Tags').required(false).as(TagEditor));
  }
}
</script>