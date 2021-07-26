import { PassedData } from '~/typings';
import { FormPassedData, FormBuilderPassedData } from './abstractions/formPassedData';

export class FormLabel extends FormPassedData {
  passedData: PassedData = {};
  content: string = '';

  get show() {
    return this.content !== '';
  }
}

export class FormLabelBuilder extends FormBuilderPassedData {
  item: FormLabel;

  constructor(label: FormLabel) {
    super();
    this.item = label;
  }
}
