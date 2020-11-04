<template>
  <v-card class="px-6">
    <cld-image
        v-if="quest.image !== ''"
        :public-id="quest.image"
        dpr="auto"
        responsive="width"
        width="auto"
        crop="scale"
        loading="lazy"
    >
    </cld-image>
    <v-img v-else src="../assets/background1.jpg" height="200px"></v-img>

    <v-card-title>{{ quest.name }}</v-card-title>
    <v-card-subtitle>{{ quest.type }}</v-card-subtitle>

    <div class="d-flex flex-column align-center font-weight-bold pb-5 text-h6">
      <p class="ma-0">REWARD</p>
      <p>{{ quest.reward }}</p>
      <mark-completed-quest-dialog
          :dialog="dialog"
          @toggleDialog="dialog = !dialog"
          @questCompleted="questCompleted"
          v-if="getLoggedUserRole !== ROLES.STUDENT"
          class="my-4"
      />
    </div>

    <card-bottom-description>
      {{ quest.description }}
    </card-bottom-description>
  </v-card>
</template>

<script>
import {mapGetters, mapMutations} from 'vuex';
import {UPDATE_USER} from '@/utils/macros/mutation-types';
import {ROLES} from '@/utils/macros/roles';
import CardBottomDescription from "@/components/CardBottomDescription";
import MarkCompletedQuestDialog from "@/components/dialogs/MarkCompletedQuestDialog";

export default {
  name: 'QuestCard',
  components: {MarkCompletedQuestDialog, CardBottomDescription},
  data: () => ({
    dialog: false,
    ROLES
  }),
  props: {
    quest: {
      type: Object
    }
  },
  computed: {
    ...mapGetters('user', ['getLoggedUserRole', 'getThisUserRoleArray']),
  },
  methods: {
    ...mapMutations('user', [UPDATE_USER]),
    questCompleted(students) {
      students.map(student =>
          this.$store.dispatch('user/updateUser',{
            user: {...student, coins: parseInt(student.coins) + this.quest.reward},
            userArray: this.getThisUserRoleArray(student)
          })
      );
      this.dialog = false;
    }
  }
};
</script>

<style scoped></style>
