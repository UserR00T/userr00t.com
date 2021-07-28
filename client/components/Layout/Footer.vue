<template>
  <footer class="py-12 md:flex md:items-center md:justify-between">
    <section class="flex justify-center space-x-6 md:order-2">
      <span class="text-gray-400 hover:text-gray-500" @click="toggleDarkMode">
        <SvgSun v-show="darkMode" />
        <SvgMoon v-show="!darkMode" />
      </span>
      <a href="https://github.com/UserR00T/userr00t.com" rel="noreferrer noopener" class="text-gray-400 hover:text-gray-500">
        <span class="sr-only">GitHub</span>
        <SvgGithub />
      </a>
    </section>
    <aside class="mt-8 md:mt-0 md:order-1">
      <p class="text-base text-center text-gray-400">Made with &lt;3 by UserR00T. <nuxt-link to="/dashboard" class="text-red-400">Dashboard</nuxt-link></p>
    </aside>
  </footer>
</template>


<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';

// TODO: Move to a more general location (plugin, vuex, or something else)
@Component<LayoutFooter>({
  head() {
    return {
      bodyAttrs: {
        class: this.darkMode ? 'dark' : '',
      }
    }
  },
  created() {
    this.darkMode = localStorage.getItem('darkMode') === 'true';
  }
})
export default class LayoutFooter extends Vue {
  darkMode = false;

  toggleDarkMode() {
    this.darkMode = !this.darkMode;
    localStorage.setItem('darkMode', this.darkMode.toString());
  }
}
</script>