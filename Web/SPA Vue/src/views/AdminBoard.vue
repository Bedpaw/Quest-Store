<template>
  <v-container class="pl-12">
    <v-row>
      <v-col cols="12">
        <v-card>
          <users-table :users="getUsers"></users-table>
        </v-card>
      </v-col>

    </v-row>

    <v-row>
      <v-col cols="12">
        <v-card>
          <classrooms-table :classrooms="getClasses"></classrooms-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>

import UsersTable from "../components/data-tables/UsersTable";
import {ROUTES} from "../utils/macros/routes";
import {mapGetters} from 'vuex';
import ClassroomsTable from "../components/data-tables/ClassroomsTable";
export default {

  name: "AdminBoard",
  components: {ClassroomsTable, UsersTable},
  data: () => ({
  }),
  computed: {
    ...mapGetters('classroom', [
      'getClasses',
    ]),
    ...mapGetters('user', [
      'getUsers', 'getMentors'
    ]),
  },
  methods: {
    openClassDetails(_classId) {
      this.$router.push(ROUTES.classroom.name + '/' + _classId )
    }
  }
};
</script>

<style scoped>

</style>
