<template>
  <v-card>
    <v-img src="../assets/background1.jpg" height="200px"></v-img>
    <v-card-title>
      {{ quest.name }}
    </v-card-title>

    <v-card-subtitle>
      {{ quest.type }}
    </v-card-subtitle>

    <div class="d-flex flex-column align-center font-weight-bold pb-5 text-h6">
      <p class="ma-0">REWARD</p>
      {{ quest.reward }}

      <v-dialog
        v-if="getLoggedUserRole !== ROLES.STUDENT"
        v-model="dialog"
        max-width="500px"
        class="my-4"
      >
        <!--Button activator-->
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="primary"
            dark
            class="mb-2"
            v-bind="attrs"
            @click="dialog = true"
          >
            Mark completed quest
          </v-btn>
        </template>
        <v-card
          class="d-flex flex-column align-center font-weight-bold pb-5 text-h6"
        >
          <v-card-title class="ma-0"
            >Select students, which did quest</v-card-title
          >
          <v-select
            v-model="students"
            :items="studentsSelectList"
            :menu-props="{ maxHeight: '400' }"
            label="Students"
            multiple
          ></v-select>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" text @click="dialog = false">
              Cancel
            </v-btn>
            <v-btn color="blue darken-1" text @click="questCompleted">
              Save
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>

    <v-card-actions>
      <v-btn color="orange lighten-2" text>
        Description
      </v-btn>
      <v-spacer></v-spacer>

      <v-btn icon @click="show = !show">
        <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
      </v-btn>
    </v-card-actions>

    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
          {{ quest.description }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';
import { UPDATE_USER } from '@/utils/macros/mutation-types';
import { ROLES } from '@/utils/macros/roles';

export default {
  name: 'QuestCard',
  data: () => ({
    show: false,
    dialog: false,
    students: [],
    studentsSelectList: {},
    ROLES
  }),
  created() {
    this.studentsSelectList = this.getStudents.map(student => {
      return {
        text: this.getFullName(student),
        value: student
      };
    });
  },
  props: {
    quest: {
      type: Object
    }
  },
  computed: {
    ...mapGetters('user', ['getStudents', 'getFullName', 'getLoggedUserRole'])
  },
  methods: {
    ...mapMutations('user', [UPDATE_USER]),
    questCompleted() {
      console.log(this.students);
      this.students.map(student =>
        this.UPDATE_USER({
          ...student,
          coins: parseInt(student.coins) + this.quest.reward
        })
      );
      this.dialog = false;
    }
  }
};
</script>

<style scoped></style>
