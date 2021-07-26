import { PassedData } from '~/typings';
import { FormTheme } from './formTheme';
import { FormGroup, FormGroupBuilder } from './formGroup';
import { FormInput, FormInputBuilder } from './formInput';

export class FormBuilder {
  groups: FormGroup[] = [];
  theme: FormTheme = {
    form: [],
    group: [],
    container: [],
    input: [],
    label: [],
  };
  data: PassedData = {};

  constructor(builder?: (formBuilder: FormBuilderData) => FormBuilderData) {
    if (!builder) {
      this.newGroup();
      return;
    }
    builder(new FormBuilderData(this));
    this.newGroup();
  }

  withInput(id: string, type: string, builder?: (formInputBuilder: FormInputBuilder) => FormInputBuilder) {
    const input = new FormInput(id, type);
    input.passedData['class'] = this.theme[`input:${type}`] || this.theme.input;
    input.label.passedData['class'] = this.theme[`label:${type}`] || this.theme.label;
    input.label.content = id;
    if (builder) {
      builder(new FormInputBuilder(input));
    }
    this.groups[this.groups.length - 1].inputs.push(input);
    return this;
  }

  newGroup(builder?: (formGroup: FormGroupBuilder) => FormGroupBuilder) {
    const formGroup = new FormGroup();
    formGroup.passedData['class'] = this.theme[`group:${this.groups.length}`] || this.theme.group;
    if (builder) {
      builder(new FormGroupBuilder(formGroup));
    }
    this.groups.push(formGroup);
    return this;
  }
}

export class FormBuilderData {
  formBuilder: FormBuilder;

  constructor(formBuilder: FormBuilder) {
    this.formBuilder = formBuilder;
  }

  withTheme(theme: FormTheme) {
    this.formBuilder.theme = {
      ...this.formBuilder.theme,
      ...theme,
    };
    return this;
  }
}
