<template>
  <div>
    <!--Search -->
    <v-text-field v-model="search" label="Search" single-line clearable class="px-4"/>

    <v-data-table
        :items="getQuests"
        :headers="headers"
        :search="search"
    >
      <!--Styling reward column -->
      <template v-slot:item.reward="{ item }">
        <v-chip small color="yellow" style="font-weight: bold">
          {{ item.reward }}
        </v-chip>
      </template>

      <!--Styling type column -->
      <template v-slot:item.type="{ item }">
        <v-chip small :color=questTypeChipColor(item.type) style="font-weight: bold">
          {{ item.type }}
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
          <v-toolbar-title>Quests Manager</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer/>

          <quest-data-dialog
              :dialog="dialog"
              :current-item="currentItem"
              @toggleDialog="dialog = !dialog"
              @itemChanged="saveChange"
          />
        </v-toolbar>

      </template>

      <!--No data view-->
      <template v-slot:no-data>
        <p>No quests available</p>
      </template>

    </v-data-table>
  </div>
</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import {ADD_QUEST, DELETE_QUEST, UPDATE_QUEST} from "@/utils/macros/mutation-types";
import {questTableHeaders} from "@/components/data-tables/table-headers";
import {dataTableMixin} from "@/mixins/dataTablesMixin";
import {Quest} from "@/structures/quest";
import QuestDataDialog from "@/components/data-tables/dialogs/QuestDataDialog";
import {QUEST_TYPES} from "@/utils/macros/quest-types";

export default {
  name: "QuestsTable",
  components: {QuestDataDialog},
  data: () => ({
    search: "",
    headers: questTableHeaders
  }),
  mixins: [dataTableMixin],
  computed: {
    ...mapGetters('quest', [
      'getQuests', 'getQuestById'
    ]),
  },
  created() {
    this.$store.dispatch('quest/fetchQuests')
  },
  methods: {
    ...mapMutations('quest', [
      ADD_QUEST, DELETE_QUEST, UPDATE_QUEST
    ]),
    deleteItem(quest) {
      if (confirm('Are you sure you want to delete this quest?')) {
        this.$store.dispatch('quest/deleteQuest', quest)
      }
    },
    saveChange(changedItem) {
      // Try to find quest
      let quest = this.getQuestById(changedItem.id)

      // Quest exist, so update him
      if (quest) {
        quest = Object.assign(quest, changedItem)
        this.$store.dispatch('quest/updateQuest', quest)
      }
      // Quest not found, so create
      else {
        quest = new Quest({...changedItem})
        this.$store.dispatch('quest/addQuest', quest)
      }
      this.clearEditedItem()
    },
    questTypeChipColor(questType) {
      return questType === QUEST_TYPES.EXTRA ? 'blue' : 'green'
    }
  }
}
</script>
