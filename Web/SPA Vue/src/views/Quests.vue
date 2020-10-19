<template>
    <v-container>
      <grid-container title="Extra Quests" :items="getExtraQuests">
        <template v-slot:default="slotProps">
          <quest-card :quest="slotProps.item"></quest-card>
        </template>
      </grid-container>

      <grid-container title="Basic Quests" :items="getBasicQuests">
        <template v-slot:default="slotProps">
          <quest-card :quest="slotProps.item"></quest-card>
        </template>
      </grid-container>
    </v-container>
</template>

<script>
import {mapGetters} from "vuex";
import QuestCard from "@/components/QuestCard";
import GridContainer from "@/components/GridContainer";

export default {
  name: "Quests",
  components: {GridContainer, QuestCard},
  computed: {
    ...mapGetters('quest', [
      'getQuests', 'getExtraQuests', 'getBasicQuests'
    ]),
  },
  created() {
    this.$store.dispatch('quest/fetchQuests')

  }
}
</script>
