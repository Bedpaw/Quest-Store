<template>
  <v-card class="d-flex flex-column justify-center align-center card ">
    <v-card-title class="mb-6 text-h5 font-weight-bold">
      Your account has not been registered in QuestStore
    </v-card-title>
    <v-card-subtitle class="text-h6">
      Please contact with administrator
    </v-card-subtitle>
    <v-btn
        class="px-12 py-4 mt-8"
        @click="window.location.reload(false)"
        color="yellow"
    >
      Refresh page
    </v-btn>
    <v-btn
        class="px-12 py-4 mt-8 warning"
        @click="$auth.logout()"
    >
      Log out
    </v-btn>
  </v-card>
</template>

<script>
export default {
  name: "loggedAsGuest"
}
</script>

<style scoped>
.card {
  background: rgba(255,255,255,0.9);
}
</style>
