<template>
  <v-card class="d-flex flex-column justify-center align-center card">
    <v-card-title class="mb-6 text-h3 font-weight-bold"
      >Welcome in QuestStore</v-card-title
    >
    <v-card-subtitle class="text-h6">Please log in to continue</v-card-subtitle>
    <v-btn class="px-12 py-4 mt-8" @click="login" color="yellow">Log in</v-btn>
  </v-card>
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
