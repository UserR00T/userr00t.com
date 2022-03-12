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
    <aside class="w-1/5 sm:w-3/5" ref="space"></aside>
  </section>
</template>

<script lang="ts">
import { Vue, Component, Watch } from 'vue-property-decorator';
// @ts-ignore - no types file found for this module
import Sparticles from 'sparticles';

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
    new Sparticles(this.$refs['space'], {
      composition: 'source-over',
      count: 350,
      speed: 4,
      parallax: 0,
      direction: 40,
      xVariance: 1,
      yVariance: 1,
      rotate: true,
      rotation: 1,
      alphaSpeed: 6.5,
      alphaVariance: 1,
      minAlpha: 0,
      maxAlpha: 1,
      minSize: 1,
      maxSize: 10,
      style: 'both',
      bounce: false,
      drift: 1,
      glow: 0,
      twinkle: false,
      color: ['random'],
      shape: 'triangle',
      imageUrl: '',
    });

    window.dispatchEvent(new Event('resize'));
  },
})
export default class Index extends Vue {
}
</script>