<template>
  <v-col cols="12" lg="8" class="mx-auto">
    <v-card class="bg">
      <v-card-title class="flex justify-center pa-0 text-md-h4 font-weight-bold">My classes</v-card-title>
      <v-card-text class="flex flex-column align-center">

        <v-row class="text-center text-h6">
          <v-col class="ma-0 pt-2 col-sm-3 font-weight-bold">Name</v-col>
          <v-col cols="12" class="ma-0 pt-2 col-sm-3 font-weight-bold">Mentors</v-col>
          <v-col cols="12" class="ma-0 pt-2 col-sm-3 font-weight-bold">Students</v-col>
          <v-col cols="12" class="ma-0 pt-2 col-sm-3 font-weight-bold">Details</v-col>
        </v-row>
        <v-divider class="mb-2"></v-divider>

        <v-row v-for="_class in getLoggedUser.classrooms" :key="_class.id" class="text-center border-bottom mx-1">
          <v-divider class="mb-2"></v-divider>
          <v-col cols="12" class="ma-0 pt-5 col-sm-3">{{ _class.name }}</v-col>
          <v-col cols="12" class="ma-0 pt-5 col-sm-3">{{ _class.mentors.length }}</v-col>
          <v-col cols="12" class="ma-0 pt-5 col-sm-3">{{ _class.students.length }}</v-col>
          <v-col cols="12 col-sm-3">
            <v-btn class="primary" @click="$router.push(ROUTES.classroom.name + '/' + _class.id)">
              Details
            </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-col>
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

<style scoped>
.bg {
  background-color: rgb(139 239 246);
}
.border-bottom {
  border-bottom: 1px solid #b8b7b7;
}
</style>
