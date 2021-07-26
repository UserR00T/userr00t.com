import { PassedData } from '~/typings';
import { FormLabel, FormLabelBuilder } from './formLabel';
import { FormPassedData, FormBuilderPassedData } from './abstractions/formPassedData';

export class FormInput extends FormPassedData {
  id: string;
  type: string;
  label: FormLabel = new FormLabel();
  component: any = 'input';
  passedData: PassedData = {
    required: true,
  };
  passedEvents: PassedData = {};

  constructor(id: string, type: string) {
    super();
    this.id = id;
    this.type = type;
  }
}

export class FormInputBuilder extends FormBuilderPassedData {
  item: FormInput;

  constructor(input: FormInput) {
    super();
    this.item = input;
  }

  withLabel(content: string | ((formBuilder: FormLabelBuilder) => FormLabelBuilder)) {
    if (typeof content === 'string') {
      this.item.label.content = content;
      return this;
    }
    content(new FormLabelBuilder(this.item.label));
    return this;
  }

  required(bool: boolean) {
    this.item.passedData['required'] = bool;
    return this;
  }

  as(component: any) {
    this.item.component = component;
    return this;
  }

  limit(max: number, min: number = 0) {
    this.item.passedData['maxlength'] = max;
    this.item.passedData['minlength'] = min;
    return this;
  }

  on(event: string, callback: any) {
    this.item.passedEvents[event] = callback;
    return this;
  }
}
