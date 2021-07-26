import { PassedData } from '~/typings';
import { FormInput } from './formInput';
import { FormPassedData, FormBuilderPassedData } from './abstractions/formPassedData';

export class FormGroup extends FormPassedData {
  inputs: FormInput[] = [];
  passedData: PassedData = {};
  component: any = 'section';
}

export class FormGroupBuilder extends FormBuilderPassedData {
  item: FormGroup;

  constructor(group: FormGroup) {
    super();
    this.item = group;
  }

  withComponent(component: any) {
    this.item.component = component;
    return this;
  }
}
