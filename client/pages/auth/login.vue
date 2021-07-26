<template>
  <section>
    <form-builder :form.sync="form" @validated="validated"></form-builder>
  </section>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import { FormBuilder } from '~/plugins/formBuilder';
import { DashboardTheme } from '~/themes';

@Component
export default class AuthLogin extends Vue {
  form = new FormBuilder((x) => x.withTheme(DashboardTheme))
    .withInput('username', 'text', (x) => x.withLabel('Username').limit(16))
    .withInput('Password', 'password', (x) => x.withLabel('Password'))
    .withInput('submit', 'submit', (x) => x.withLabel('').with('value', 'Submit'));

  async validated() {
    console.log('validated', this.form);
    try {
      const { token } = await this.$axios.$post('auth/login', this.form.data);
      localStorage.setItem('token', token);
      this.$router.push(this.$route.query['t']?.toString() || '/dashboard');
    } catch (ex) {
      // Only catch axios server response errors
      if (!ex.response) {
        throw ex;
      }
      switch (ex.response.status) {
        case 404:
          this.$notify({
            type: 'warn',
            title: 'Account not found',
            text: 'The account provided was not found.',
          });
          break;

        case 401:
          this.$notify({
            type: 'warn',
            title: 'Invalid credentials',
            text: 'Invalid username or password combination.',
          });
          break;

        default:
          break;
      }
    }
  }
}
</script>