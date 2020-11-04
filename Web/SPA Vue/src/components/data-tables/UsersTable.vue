<template>
  <div>
    <!--Search -->
    <v-text-field
      v-model="search"
      label="Search"
      single-line
      clearable
      class="px-4"
    />

    <v-data-table :items="getStudentsAndMentors" :headers="headers" :search="search">
      <!--Join name + surname in first column -->
      <template v-slot:item.name="{ item }">
        {{ getFullName(item) }}
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
          {{ item.coins ? item.coins : "-" }}
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

          <v-spacer />

          <user-data-dialog
            :dialog="dialog"
            :current-item="currentItem"
            @toggleDialog="dialog = !dialog"
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
import { ROLES } from '@/utils/macros/roles';
import UserDataDialog from './dialogs/UserDataDialog';
import { User } from '@/structures/user';
import { mapGetters, mapMutations } from 'vuex';
import {
  ADD_USER,
  DELETE_USER,
  UPDATE_USER
} from '@/utils/macros/mutation-types';
import { userTableHeaders } from '@/components/data-tables/table-headers';
import { dataTableMixin } from '@/mixins/dataTablesMixin';

export default {
  name: 'TestTable',
  components: { UserDataDialog },
  data: () => ({
    search: '',
    headers: userTableHeaders
  }),
  mixins: [dataTableMixin],
  computed: {
    ...mapGetters('user', ['getStudents', "getMentors", "getFullName", 'getUserById', 'getThisUserRoleArray']),
    getStudentsAndMentors() {
      return [...this.getStudents, ...this.getMentors]
    }
  },

  created() {
    this.$store.dispatch('user/fetchMentors')
    this.$store.dispatch('user/fetchStudents')
  },
  methods: {
    ...mapMutations('user', [ADD_USER, UPDATE_USER, DELETE_USER]),
    deleteItem(user) {
      if (confirm('Are you sure you want to delete this user?')) {
        this.$store.dispatch('user/deleteUser', {
          user: user,
          userArray: this.getThisUserRoleArray(user)
        });
      }
    },
    saveChange(changedItem) {
      // Try to find user
      let user = this.getUserById(changedItem.id);

      // User exist, so update him
      if (user) {
        user = Object.assign(user, changedItem);
        console.log(user)
        this.$store.dispatch('user/updateUser', {
          user: user,
          userArray: this.getThisUserRoleArray(user)
        });
      }
      // User not found, so create
      else {
        user = new User({ ...changedItem });
        this.$store.dispatch('user/addUser',{
          user: user,
          userArray: this.getThisUserRoleArray(user)
        });
      }
      this.clearEditedItem();
    },
    setRoleChipColor(role) {
      return {
        [ROLES.ADMIN]: 'orange',
        [ROLES.MENTOR]: 'blue',
        [ROLES.STUDENT]: 'green',
        [ROLES.GUEST]: 'gray'
      }[role];
    }
  }
};
</script>

<style scoped></style>
