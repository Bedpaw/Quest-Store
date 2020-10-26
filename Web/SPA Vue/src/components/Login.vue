<template>
  <div class="home">
    <div v-if="!$auth.loading">
      <v-btn v-if="!$auth.isAuthenticated" @click="login">Log in</v-btn>
      <v-btn v-if="$auth.isAuthenticated" @click="logout">Log out</v-btn>
    </div>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  name: 'login',
  computed: {
    ...mapMutations('profile', ['setUser'])
  },
  methods: {
    // Log the user in
    login() {
      this.$auth.loginWithRedirect();
    },
    // Log the user out
    logout() {
      this.$auth.logout({
        returnTo: window.location.origin
      });
    }
  }
};
</script>
