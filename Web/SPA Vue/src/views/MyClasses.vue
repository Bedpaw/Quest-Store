<template>
  <v-card>
    <v-card-title class="flex justify-center pa-0">My classes</v-card-title>

    <v-card-text class="flex flex-column align-center">
      <div
        v-for="_class in getClassesByUserId(getLoggedUser.id)"
        :key="_class.id"
        class="d-flex justify-center"
      >
        <p>{{ _class.name }}</p>
        <v-btn @click="$router.push(ROUTES.classroom.name + '/' + _class.id)">
          Details
        </v-btn>
      </div>
    </v-card-text>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'MyClasses',
  computed: {
    ...mapGetters('classroom', ['getClassesByUserId']),
    ...mapGetters('user', ['getLoggedUser', 'getFullName'])
  }
};
</script>

<style scoped></style>
