import { PassedData } from '~/typings';

export abstract class FormPassedData {
  abstract passedData: PassedData;
}

export abstract class FormBuilderPassedData {
  abstract item: FormPassedData;

  withData(data: any) {
    this.item.passedData = {
      ...this.item.passedData,
      ...data,
    };
    return this;
  }

  with(key: string, value?: any) {
    this.item.passedData[key] = value ?? true;
    return this;
  }

  withConcat(key: string, value: any) {
    return this.with(key, this.item.passedData[key].concat(value));
  }
}
