<template>
  <div>
    <!--Search -->
    <v-text-field v-model="search" label="Search" single-line clearable class="px-4" />

    <v-data-table
        :items="classrooms"
        :headers="headers"
        :search="search"
    >

      <!--Concat mentor fullName -->
      <template v-slot:item.mentor="{ item }">
        {{ item.mentors.map(mentor => mentor.getFullName().toString())}}
      </template>

      <!--Number of students column -->
      <template v-slot:item.students="{ item }">
        {{ item.students.length}}
      </template>

      <!--Add editing/deleting buttons -->
      <template v-slot:item.actions="{ item }">
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
import {mapMutations} from "vuex";
import {ADD_CLASS} from "../../utils/macros/mutation-types";
import ClassDataDialog from "./dialogs/ClassDataDialog";

export default {
name: "ClassroomsTable",

  components: {ClassDataDialog},
  props: {
    classrooms: {
      type: Array
    }
  },
  data: () => ({
    search: "",
    dialog: false,
    currentItem: {},
    headers: [
      {
        text: 'Name',
        value: 'name',
        sortable: true,
        filterable: true
      },
      {
        text: 'Mentors',
        value: 'mentors',
        sortable: true,
        filterable: true
      },
      {
        text: 'Number of students',
        value: 'students',
        sortable: true,
        filterable: true
      },
      {
        text: 'Actions',
        value: 'actions',
        sortable: false
      },
    ],
  }),
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
    }
  }
}
</script>

<style scoped>

</style>
