import { FormTheme } from '~/plugins/formBuilder';

export const DashboardTheme = new class DashboardTheme extends FormTheme {
  form = [ 'w-full', 'md:w-1/2' ];
  group = [];
  container = [ 'flex', 'flex-col', 'mb-2', 'flex-1' ];
  label = [ 'mb-1', 'text-lg', 'font-bold', 'text-gray-800', 'dark:text-gray-400' ];
  input = [ 'px-2', 'py-2', 'mx-2', 'rounded-md', 'shadow', 'border-b', 'focus:outline-none', 'focus:border-red-500', 'dark:bg-gray-700' ];
  'input:submit' = [ 'px-2', 'py-2', 'mx-2', 'rounded-md', 'shadow', 'hover:bg-red-500', 'hover:text-white', 'dark:bg-gray-700', 'dark:hover:bg-red-500' ];
  'group:1' = [ 'flex', 'mt-8' ];
}