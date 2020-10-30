<template>
  <v-dialog v-model="dialog" max-width="500px">
    <!--Button activator-->
    <template v-slot:activator="{ on, attrs }">
      <v-btn
        color="primary"
        dark
        class="mb-2"
        v-bind="attrs"
        @click="$emit('toggleDialog')"
      >
        Add User
      </v-btn>
    </template>

    <!--Form-->
    <v-card>
      <v-card-title class="d-flex justify-center">
        <span class="headline">{{ formTitle }}</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-form ref="form" v-model="valid" lazy-validation>
            <v-row>
              <v-col cols="12" sm="12" md="6">
                <v-text-field
                  v-model="editedItem.name"
                  label="Name"
                  :rules="nameRules"
                />
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="editedItem.surname"
                  label="Surname"
                  :rules="surnameRules"
                />
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="editedItem.email"
                  label="Email"
                  :rules="emailRules"
                />
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <v-select
                  :items="roles"
                  v-model="editedItem.role"
                  label="Role"
                />
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="editedItem.coins"
                  label="Account Balance"
                  type="number"
                  step="10"
                  min="0"
                  :rules="positive"
                />
              </v-col>
              <v-col cols="12" sm="12" md="6">
                <upload-file @image-uploaded="setImage"></upload-file>
              </v-col>
            </v-row>
          </v-form>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="$emit('toggleDialog')">
          Cancel
        </v-btn>
        <v-btn color="blue darken-1" text @click="save">
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { ROLES } from '@/utils/macros/roles';
import { dataTableDialogMixin } from '@/mixins/dataTablesMixin';
import {
  nameRules,
  surnameRules,
  descriptionRules,
  emailRules,
  positive
} from '@/components/data-tables/validators';
import UploadFile from "@/components/utils/uploadFile";

export default {
  name: 'UserDataDialog',
  components: {UploadFile},
  mixins: [dataTableDialogMixin],
  data() {
    return {
      emptyItemTemplate: {
        name: '',
        surname: '',
        coins: 50,
        email: '',
        role: ROLES.STUDENT
      },
      surnameRules,
      nameRules,
      descriptionRules,
      positive,
      emailRules,
      formName: 'User',
      roles: Object.values(ROLES)
    };
  }
};
</script>
