import { Context } from '@nuxt/types';
import { Component, Vue } from 'vue-property-decorator';
import { FormBuilder } from '~/plugins/formBuilder';
import { DashboardTheme } from '~/themes';

@Component
export class EditEntity extends Vue {
  type = '';
  entity: any;
  form = new FormBuilder((x) => x.withTheme(DashboardTheme));

  created() {
    this.form.groups = [];
    this.form.newGroup();

    this.form.withInput('id', 'text', (x) =>
      x.withLabel('ID').with('placeholder', 'This field will be populated when submitted').with('readonly').withConcat('class', 'text-gray-500 dark:text-gray-400')
    );
    this.inputs();
    this.form.newGroup();
    if (this.$route.params['id'] !== 'new') {
      this.form.withInput('delete', 'button', (x) =>
        x.on('click', this.deleteEntity).withLabel('').with('value', 'Delete').withConcat('class', 'bg-red-300 hover:bg-red-500 hover:text-white dark:bg-red-400 dark:hover:bg-red-500 dark:border-red-400')
      );
    }
    this.form.withInput('submit', 'submit', (x) => x.withLabel('').with('value', 'Submit'));

    this.form.data = this.entity || {};
  }

  inputs() {}

  async validated() {
    if (this.$route.params['id'] !== 'new') {
      await this.$axios.$put(`${this.type}/${this.$route.params['id']}`, this.form.data);
      this.entity = this.form.data;
      return;
    }
    // TODO: figure out how to show "delete" button once post-ed
    this.form.data = (await this.$axios.$post(this.type, this.form.data)) || this.form.data;
    this.entity = this.form.data;
    if (this.form.data['id']) {
      this.$route.params['id'] = this.form.data['id'];
      history.pushState({}, '', this.$route.path.replace('new', this.form.data['id']));
    }
  }

  async deleteEntity() {
    await this.$axios.$delete(`${this.type}/${this.$route.params['id']}`);
    this.form.data['id'] = undefined;
  }
}

export async function fetchEntity(ctx: Context, type: string) {
  const { params, $axios } = ctx;
  let entity = undefined;

  if (params['id'] !== 'new') {
    entity = await $axios.$get(`${type}/${params['id']}`);
  }

  return { entity };
}
