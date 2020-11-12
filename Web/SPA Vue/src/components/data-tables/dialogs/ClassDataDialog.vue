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
        Add Classroom
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
                <v-select
                  v-model="editedItem.students"
                  :items="studentsSelectList"
                  :menu-props="{ maxHeight: '400' }"
                  label="Students"
                  multiple
                ></v-select>
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <v-select
                  v-model="editedItem.mentors"
                  :items="mentorsSelectList"
                  :menu-props="{ maxHeight: '400' }"
                  label="Mentors"
                  multiple
                ></v-select>
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
import { dataTableDialogMixin } from '@/mixins/dataTablesMixin';
import { mapGetters } from 'vuex';
import { nameRules } from '@/components/data-tables/validators';
import UploadFile from '@/components/utils/uploadFile';

export default {
  name: 'ClassDataDialog',
  components: { UploadFile },
  mixins: [dataTableDialogMixin],
  data() {
    return {
      emptyItemTemplate: {
        name: '',
        mentors: [],
        students: []
      },
      formName: 'Class',
      nameRules
    };
  },
  computed: {
    ...mapGetters('user', [
      'getStudents',
      'getFullName',
      'getMentors',
      'getUsersAsFullNameAndDataFormat'
    ]),
    studentsSelectList() {
      // data in proper form for v-select
      return this.getUsersAsFullNameAndDataFormat(this.getStudents);
    },
    mentorsSelectList() {
      // data in proper form for v-select
      return this.getUsersAsFullNameAndDataFormat(this.getMentors);
    }
  }
};
</script>
