<template>
  <v-card class="d-flex justify-center card py-12">
    <v-progress-circular
        indeterminate
        color="green"
        size="200"
    ></v-progress-circular>
  </v-card>
</template>

<script>
export default {
name: "loadingMenu",
}
</script>

<style scoped>
.card {
  background: rgba(255,255,255,0.9);
}
</style>
