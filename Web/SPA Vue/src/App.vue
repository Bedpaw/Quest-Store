<template>
  <v-app>
    <v-main class="background-image">
      <navbar v-if="$auth.isAuthenticated && $auth.isGuest() === false" />
      <router-view class="pl-16"></router-view>
    </v-main>
  </v-app>
</template>

<script>
import Navbar from '@/components/Navbar';
export default {
  name: 'App',
  components: { Navbar }
};
</script>
<style>
.background-image {
  background-image: url('../public/layout.jpg');
  background-repeat: repeat-y;
}
</style>
