<template>
  <section class="w-5/6 mx-auto dark:bg-gray-600">
    <notifications position="bottom right" :pause-on-hover="true" />
    <LayoutHeader />

    <main class="min-h-screen py-4 text-gray-600 dark:text-gray-300">
      <Nuxt />
    </main>

    <LayoutFooter />
  </section>
</template>

<style>
ul > li {
  @apply inline;
}

.nuxt-link-exact-active {
  @apply text-gray-900 border-b-2 border-red-500;
}

.nuxt-link-exact-active:hover {
  @apply border-red-400;
}

</style>