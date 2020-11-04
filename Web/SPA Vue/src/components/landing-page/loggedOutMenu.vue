<template>
  <v-col cols="12" xl="6" class="mx-auto">
    <v-card class="d-flex flex-column justify-center align-center card pb-4">
      <v-card-title class="mb-6 text-h3 font-weight-bold">Welcome in QuestStore</v-card-title>
      <img src="@/assets/artifact.jpg" alt="landing image">
      <v-card-subtitle class="text-h6">Please log in to continue</v-card-subtitle>
      <v-btn class="px-12 py-4 mt-8" @click="login" color="yellow">Log in</v-btn>
    </v-card>
  </v-col>
</template>

<script>
export default {
  name: 'loggedOutMenu',
  methods: {
    login() {
      this.$auth.loginWithRedirect();
    }
  }
};
</script>

<style scoped>
.card {
  background: rgba(255, 255, 255, 0.9);
}
</style>
