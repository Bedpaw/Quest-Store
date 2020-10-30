<template>
  <v-col cols="12" md="6">
    <v-card
      class="d-flex flex-column align-center py-sm-6 lime lighten-5 hover"
      @click="$router.push(path)"
    >
      <v-icon class="flex justify-center" size="108px">{{ icon }}</v-icon>
      <v-card-title>{{ title }}</v-card-title>
    </v-card>
  </v-col>
</template>

<script>
export default {
  name: 'menuItem',
  props: {
    title: {
      required: true,
      type: String
    },
    path: {
      required: true,
      type: String
    },
    icon: {
      required: true,
      type: String
    }
  }
};
</script>

<style scoped>
.hover:hover {
  opacity: 0.9;
}
</style>
