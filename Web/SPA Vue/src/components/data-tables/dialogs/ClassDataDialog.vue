<template>
  <v-dialog
      v-model="dialog"
      max-width="500px"
  >
    <!--Button activator-->
    <template v-slot:activator="{ on, attrs }">
      <v-btn color="primary" dark class="mb-2"
             v-bind="attrs" @click="$emit('toggleDialog')">
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
          <v-row>
            <v-col cols="12" sm="12" md="6">
              <v-text-field v-model="editedItem.name" label="Name"/>
            </v-col>

            <v-col cols="12" sm="6" md="6">
              <v-select
                  v-model="editedItem.students"
                  :items="studentsSelectList"
                  :menu-props="{ maxHeight: '400' }"
                  label="Students"
                  multiple
                  hint="Pick students for your class"
                  persistent-hint
              ></v-select>
            </v-col>

            <v-col cols="12" sm="6" md="6">
              <v-select
                  v-model="editedItem.mentors"
                  :items="mentorsSelectList"
                  :menu-props="{ maxHeight: '400' }"
                  label="Mentors"
                  multiple
                  hint="Pick mentors"
                  persistent-hint
              ></v-select>
            </v-col>

          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
            color="blue darken-1"
            text
            @click="$emit('toggleDialog')"
        >
          Cancel
        </v-btn>
        <v-btn
            color="blue darken-1"
            text
            @click="save"
        >
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import {dataTableDialogMixin} from "@/mixins/dataTablesMixin";
import {mapGetters} from "vuex";

export default {
  name: "ClassDataDialog",
  mixins: [dataTableDialogMixin],
  data() {
    return {
      emptyItemTemplate: {
        name: '',
        mentors: [],
        students: [],
      },
      formName: 'Class',
      studentsSelectList: {},
      mentorsSelectList: {}
    }
  },
  created() {
    this.studentsSelectList = this.getStudents.map(student => {
      return {
        text: this.getFullName(student),
        value: student
      }
    })
    this.mentorsSelectList = this.getMentors.map(student => {
      return {
        text: this.getFullName(student),
        value: student
      }
    })
  },
  computed: {
    ...mapGetters('user', [
      'getStudents', 'getFullName', 'getMentors'
    ]),
  },
}
</script>
