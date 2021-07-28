<template>
  <section class="w-5/6 mx-auto">
    <notifications position="bottom right" :pause-on-hover="true" />
    <LayoutHeader />

    <main class="py-4 text-gray-600 dark:text-gray-300">
      <Nuxt />
    </main>

    <LayoutFooter />
  </section>
</template>