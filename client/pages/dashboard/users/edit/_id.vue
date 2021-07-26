<template>
  <form-builder :form.sync="form" @validated="validated"></form-builder>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { EditEntity, fetchEntity } from '~/mixins/EditEntity';

@Component({
  layout: 'dashboard',

  async asyncData(ctx) {
    return await fetchEntity(ctx, 'user');
  },
})
export default class EditUsers extends EditEntity {
  type = 'user';

  inputs() {
    this.form
      .withInput('username', 'text', (x) => x.withLabel('Username').limit(16))
      .withInput('password', 'password', (x) => x.withLabel('Password').with('placeholder', 'You must populate this field on every change'));
  }
}
</script>