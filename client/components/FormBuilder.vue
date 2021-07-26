<template>
  <form :class="form.theme.form" @submit.prevent="onSubmit">
    <component v-for="(group, i) in form.groups" :key="i" :is="group.component" v-bind="group.passedData">
      <div v-for="(input, j) in group.inputs" :key="j" :class="form.theme.container">
        <label :for="input.id" v-show="input.label.show" v-bind="input.label.passedData"
          >{{ input.label.content }} {{ input.type === 'range' && form.data[input.id] ? `(${form.data[input.id]})` : '' }}</label
        >

        <!-- Dynamic component v-model support -->
        <component v-if="input.passedData.value" :is="input.component" :id="input.id" :type="input.type" v-bind="input.passedData" v-on="input.passedEvents" />
        <input v-else-if="input.component === 'input'" :id="input.id" :type="input.type" v-bind="input.passedData" v-model="form.data[input.id]" />
        <textarea v-else-if="input.component === 'textarea'" :id="input.id" :type="input.type" v-bind="input.passedData" v-model="form.data[input.id]" />
        <component v-else :is="input.component" :id="input.id" :type="input.type" v-bind="input.passedData" v-model="form.data[input.id]" />
      </div>
    </component>
  </form>
</template>

<script lang="ts">
import { Vue, Prop, Component } from 'vue-property-decorator';
import { FormBuilder } from '~/plugins/formBuilder';

@Component
export default class FormBuilderComponent extends Vue {
  @Prop(FormBuilder)
  readonly form!: FormBuilder;

  onSubmit() {
    // TODO: Add more validation if needed
    this.$emit('validated', this.form);
  }
}
</script>