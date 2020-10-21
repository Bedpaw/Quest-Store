<template>
<div class="d-flex align-center justify-center fill-height background-image">
  <v-container class="container">
    <component :is="menuComponent"></component>
  </v-container>
</div>
</template>

<script>
import loggedInMenu from '@/components/landing-page/loggedInMenu'
import loggedOutMenu from "@/components/landing-page/loggedOutMenu";
import {getInstance} from "@/auth";
import loadingMenu from "@/components/landing-page/loadingMenu";
import loggedAsGuest from "@/components/landing-page/loggedAsGuest";


export default {
  name: "Home",
  components:{loggedInMenu, loggedOutMenu},
  data() {
    return {
    };
  },
  computed: {
    menuComponent: () => {
      const authService = getInstance()
      const loggedIn = authService.isAuthenticated
      const notLoading = authService.loading === false

      if(loggedIn && notLoading && authService.isGuest()) return loggedAsGuest
      if(loggedIn && notLoading) return loggedInMenu
      if(loggedIn === false && notLoading) return loggedOutMenu
      return loadingMenu
    },
  },
};
</script>

<style scoped>
.background-image {
  background-image: url('../../public/layout.jpg');

}
.container {
  border-radius: 10px;
}
</style>
