<template>
  <div class="d-flex flex-column align-center">
    <p class="text-h5 mb-0">{{ title }}</p>
    <v-btn icon @click="show = !show">
      <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
    </v-btn>

    <v-expand-transition>
      <div v-show="show">
        <slot></slot>
      </div>
    </v-expand-transition>
  </div>
</template>

<script>
export default {
  name: 'expander',
  props: {
    title: {}
  },
  data() {
    return {
      show: false
    };
  }
};
</script>

<style scoped></style>
