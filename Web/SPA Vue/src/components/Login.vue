<template>
  <div class="home">

    <div v-if="!$auth.loading">
      <button v-if="!$auth.isAuthenticated" @click="login">Log in</button>
      <button v-if="$auth.isAuthenticated" @click="logout">Log out</button>
    </div>
  </div>

</template>

<script>
import { mapMutations } from "vuex";

export default {
  name: "login",
  computed: {
    ...mapMutations("profile", ["setUser"])
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
