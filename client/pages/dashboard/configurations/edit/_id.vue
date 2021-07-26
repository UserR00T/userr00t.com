<template>
  <form-builder :form.sync="form" @validated="validated"></form-builder>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { EditEntity, fetchEntity } from '~/mixins/EditEntity';

@Component({
  layout: 'dashboard',

  async asyncData(ctx) {
    return await fetchEntity(ctx, 'configuration');
  },
})
export default class EditConfigurations extends EditEntity {
  type = 'configuration';

  inputs() {
    this.form
      .withInput('key', 'text', (x) => x.withLabel('Key'))
      .withInput('value', 'text', (x) => x.withLabel('Value').as('textarea'));
  }
}
</script>