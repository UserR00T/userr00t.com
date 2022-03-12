<template>
  <section class="flex min-h-screen">
    <section class="w-4/5 sm:w-2/5 sm:text-center lg:text-left">
      <h1 class="hero-text xl">
        <span>Hi, my name is</span>
        <span class="text-theme">UserR00T</span>
      </h1>
      <p class="my-3 text-base sm:mt-5 sm:text-lg sm:max-w-xl sm:mx-auto md:mt-5 md:text-xl lg:mx-0">
        {{ description }}
      </p>
      <Project
        v-if="latestProject"
        label="Latest Project"
        :name="latestProject.name"
        :description="latestProject.shortDescription"
        :id="latestProject.id"
        :tags="latestProject.tags"
        :url="latestProject.url"
      />
      <Project
        v-if="latestUpdatedProject"
        label="Latest Updated Project"
        :name="latestUpdatedProject.name"
        :description="latestUpdatedProject.shortDescription"
        :id="latestUpdatedProject.id"
        :tags="latestUpdatedProject.tags"
        :url="latestUpdatedProject.url"
      />
      <Skill :name="name" :skills="skills[name]" v-for="(name, i) in Object.keys(skills)" :key="i" />
    </section>
    <aside class="w-1/5 sm:w-3/5" ref="space">
      <canvas ref="canvas">
      </canvas>
    </aside>
  </section>
</template>

<script lang="ts">
import { Vue, Component, Watch } from 'vue-property-decorator';
import { Hero } from '../plugins/heroRenderer';

@Component({
  async asyncData({ $axios }) {
    let { latestProject, latestUpdatedProject, skills, description } = await $axios.$get('home');
    skills = (skills as Array<any>).reduce((acc, curr) => {
      if (!acc[curr.category]) {
        acc[curr.category] = [];
      }
      acc[curr.category].push(curr);
      return acc;
    }, {});
    return { latestProject, latestUpdatedProject, skills, description };
  },
  mounted() {
    if (!this.$refs['canvas']) {
      return;
    }

    const canvas = this.$refs['canvas'] as HTMLCanvasElement;
    const hero = new Hero(canvas);
    hero.start();
  },
})
export default class Index extends Vue {
}
</script>