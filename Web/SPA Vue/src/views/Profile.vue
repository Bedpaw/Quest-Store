<template>
<v-card>
  <v-container>
    <v-row class="d-flex justify-start">
      <v-col>
        <v-avatar>
          <img :src="$auth.user.picture">
        </v-avatar>
      </v-col>
      <v-col>
        <v-card-title>{{$auth.user.name}}</v-card-title>
      </v-col>
    </v-row>
  </v-container>
  <div>


  </div>
</v-card>
</template>

<script>

export default {
name: "Profile",
created() {
  console.log(this.$auth.user)
}
}
</script>

<style scoped>

</style>
