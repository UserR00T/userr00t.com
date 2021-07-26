<template>
  <form-builder :form.sync="form" @validated="validated"></form-builder>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { EditEntity, fetchEntity } from '~/mixins/EditEntity';

@Component({
  layout: 'dashboard',

  async asyncData(ctx) {
    return await fetchEntity(ctx, 'skill');
  },
})
export default class EditSkills extends EditEntity {
  type = 'skill';

  inputs() {
    this.form
      .withInput('category', 'text', (x) => x.withLabel('Category').limit(32))
      .withInput('name', 'text', (x) => x.withLabel('Name').limit(32))
      .withInput('value', 'range', (x) => x.withLabel('Value').with('min', 0).with('max', 100));
  }
}
</script>