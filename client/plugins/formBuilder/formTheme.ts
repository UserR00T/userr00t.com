import { PassedData } from '~/typings';

export class FormTheme implements PassedData {
  form: string[] = [];
  group: string[] = [];
  container: string[] = [];
  input: string[] = [];
  label: string[] = [];

  [key: string]: string[];
}
