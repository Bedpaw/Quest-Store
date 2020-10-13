<template>
  <div>
    <!--Search -->
    <v-text-field v-model="search" label="Search" single-line clearable class="px-4" />

    <v-data-table
        :items="getUsers"
        :headers="headers"
        :search="search"
    >
      <!--Join name + surname in first column -->
      <template v-slot:item.name="{item}">
        {{item.getFullName()}}
      </template>

      <!--Styling role column -->
      <template v-slot:item.role="{ item }">
        <v-chip small :color="setRoleChipColor(item.role)" dark>
          {{ item.role }}
        </v-chip>
      </template>

      <!--Styling account balance column -->
      <template v-slot:item.coins="{ item }">
        <v-chip small color="yellow" style="font-weight: bold">
          {{ item.coins }}
        </v-chip>
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
          <v-toolbar-title>Users Manager</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>

          <v-spacer/>

          <user-data-dialog
              :dialog="dialog"
              :current-item="currentItem"
              @dialogClosed="clearEditedUser"
              @dialogOpened="dialog=true"
              @itemChanged="saveChange"
          />
        </v-toolbar>
      </template>

      <!--No data view-->
      <template v-slot:no-data>
        <p>No users available</p>
      </template>

    </v-data-table>
  </div>
</template>

<script>
import {ROLES} from "../../utils/macros/roles";
import UserDataDialog from "./dialogs/UserDataDialog";
import {User} from "../../structures/user";
import {mapGetters, mapMutations} from "vuex";
import {ADD_USER, DELETE_USER, UPDATE_USER} from "../../utils/macros/mutation-types";

export default {
  name: "TestTable",
  components: {UserDataDialog},
  data: () => ({
    search: "",
    dialog: false,
    currentItem: {},
    headers: [
      {
        text: 'Full name',
        value: 'name',
        sortable: true,
        filterable: true
      },
      {
        text: 'Role',
        value: 'role',
        sortable: true,
        filterable: true
      },
      {
        text: 'E-mail',
        value: 'email',
        sortable: true,
        filterable: true
      },
      {
        text: 'Cool coins',
        value: 'coins',
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
  computed: {
    ...mapGetters('user', [
      'getUsers'
    ]),
    items() {
      return this.getUsers
    }
  },
  methods: {
    ...mapMutations('user', [
      ADD_USER, UPDATE_USER, DELETE_USER
    ]),
    setRoleChipColor(role) {
      return {
        [ROLES.ADMIN]: 'orange',
        [ROLES.MENTOR]: 'blue',
        [ROLES.STUDENT]: 'green',
        [ROLES.GUEST]: 'gray'
      }[role]
    },
    editItem (item) {
      this.currentItem = {...item}
      this.dialog = true
    },
    deleteItem (user) {
      if(confirm('Are you sure you want to delete this user?'))  this.DELETE_USER(user)
    },
    clearEditedUser() {
      this.dialog = false
      this.currentItem = {}
    },
    saveChange(changedItem) {
      let user = this.items.find(item => item.id === changedItem.id)

      if (user) {
        user = Object.assign(user, changedItem)
        this.UPDATE_USER(user)
      }
      else {
        user = new User({...changedItem })
        this.ADD_USER(user)
      }
      this.clearEditedUser()
    }
  }
}
</script>

<style scoped>

</style>
