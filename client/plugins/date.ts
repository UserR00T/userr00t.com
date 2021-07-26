import { Plugin } from '@nuxt/types';
import dayjs from 'dayjs';
import relativeTime from 'dayjs/plugin/relativeTime';
import { DayJsPlugin } from '~/typings';

const plugin: Plugin = (_, inject) => {
  dayjs.extend(relativeTime);

  inject('dayjs', (value: string | number | dayjs.Dayjs | Date | null | undefined) => {
    return {
      template: 'HH:mm:ss YYYY-MM-DD Z',
      default: dayjs(value),
      format() {
        return this.default.format(this.template);
      },
    } as DayJsPlugin;
  });
};
export default plugin;
