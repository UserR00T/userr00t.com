import dayjs from 'dayjs';

// Plugin: auth.ts
declare module 'vue/types/vue' {
  interface Vue {
    $loggedIn(): boolean;
  }
}

// Plugin: dayjs.ts
declare module 'vue/types/vue' {
  interface Vue {
    $dayjs(value: string | number | dayjs.Dayjs | Date | null | undefined): DayJsPlugin;
  }
}

export interface DayJsPlugin {
  template: string;
  default: dayjs.Dayjs;
  format(): string;
}

export interface PassedData<T = any> {
  [key: string]: T;
}
