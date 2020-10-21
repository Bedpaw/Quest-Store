<template>
  <v-container class="pl-12">
    <v-row>
      <v-col cols="12">
        <v-card>
          <users-table></users-table>
        </v-card>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <v-card>
          <classrooms-table></classrooms-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>

import UsersTable from "../components/data-tables/UsersTable";
import ClassroomsTable from "../components/data-tables/ClassroomsTable";

export default {
  name: "AdminBoard",
  components: {ClassroomsTable, UsersTable},

};
</script>

<style scoped>

</style>
