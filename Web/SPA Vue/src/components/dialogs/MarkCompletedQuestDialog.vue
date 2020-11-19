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
        Mark completed quest
      </v-btn>
    </template>
    <v-card
      class="d-flex flex-column align-center font-weight-bold pb-5 text-h6"
    >
      <v-card-title class="ma-0"
        >Select students, which did quest
      </v-card-title>
      <v-select
        v-model="students"
        :items="studentsSelectList"
        :menu-props="{ maxHeight: '400' }"
        label="Students"
        multiple
      ></v-select>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="$emit('toggleDialog')">
          Cancel
        </v-btn>
        <v-btn color="blue darken-1" text @click="questCompleted">
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';
import { UPDATE_USER } from '@/utils/macros/mutation-types';

export default {
  name: 'MarkCompletedQuestDialog',
  data: () => ({
    students: []
  }),
  props: {
    dialog: {
      required: true,
      type: Boolean
    }
  },
  watch: {
    dialog: function() {
      if (this.dialog === true) {
        this.$store.dispatch('user/fetchStudents');
      }
    }
  },
  computed: {
    ...mapGetters('user', ['getStudents', 'getUsersAsFullNameAndDataFormat']),
    studentsSelectList() {
      // data in proper form for v-select
      return this.getUsersAsFullNameAndDataFormat(this.getStudents);
    }
  },
  methods: {
    ...mapMutations('user', [UPDATE_USER]),
    questCompleted() {
      this.$emit('questCompleted', this.students);
      this.students = [];
    }
  }
};
</script>

<style scoped></style>
