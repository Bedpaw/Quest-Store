<template>
  <div>
    <!--Search -->
    <v-text-field v-model="search" label="Search" single-line clearable class="px-4" />

    <v-data-table
        :items="getClasses"
        :headers="headers"
        :search="search"
    >

      <!--Concat mentor fullName -->
      <template v-slot:item.mentors="{ item }">
        {{ getMentorsFullNamesAsString(item) }}
      </template>

      <!--Number of students column -->
      <template v-slot:item.students="{ item }">
        {{ item.students.length}}
      </template>

      <!--Add editing/deleting buttons -->
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="openClassDetails(item.id)">
          mdi-eye
        </v-icon>
        <v-icon small class="mr-2" @click="editItem(item)">
          mdi-pencil
        </v-icon>
        <v-icon small @click="deleteItem(item)">
          mdi-delete
        </v-icon>
      </template>

      <!--Add Header and Dialog-->
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Class Manager</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>

          <v-spacer/>

          <class-data-dialog
              :dialog="dialog"
              :current-item="currentItem"/>
        </v-toolbar>
      </template>

      <!--No data view-->
      <template v-slot:no-data>
        <p>No classrooms available</p>
      </template>

    </v-data-table>
  </div>
</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import {ADD_CLASS} from "@/utils/macros/mutation-types";
import ClassDataDialog from "./dialogs/ClassDataDialog";
import {classroomTableHeaders} from "@/components/data-tables/table-headers";
import {ROUTES} from "@/utils/macros/routes";

export default {
name: "ClassroomsTable",

  components: {ClassDataDialog},
  data: () => ({
    search: "",
    dialog: false,
    currentItem: {},
    headers: classroomTableHeaders
  }),
    computed: {
      ...mapGetters('classroom', [
        'getClasses'
      ]),
      ...mapGetters('user', [
        'getFullName',  'getUsersFullNameAsString'
      ]),
    },
  created() {
  },
  methods: {
    ...mapMutations('user', [
      ADD_CLASS
    ]),
    editItem (item) {
      this.currentItem = {...item}
      this.dialog = true
    },
    deleteItem (user) {
      if(confirm('Are you sure you want to delete this user?')) {console.log(user)}
    },
    clearEditedUser() {
      this.dialog = false
      this.currentItem = {}
    },
    saveChange(changedItem) {
      console.log(changedItem)
    },
    getMentorsFullNamesAsString(_class) {
     return this.getUsersFullNameAsString(_class.mentors)
    },
    openClassDetails(_classId) {
      this.$router.push(ROUTES.classroom.name + '/' + _classId )
    }
  }
}
</script>

<style scoped>

</style>
