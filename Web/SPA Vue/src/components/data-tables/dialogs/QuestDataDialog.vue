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
        Add Quest
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
              <v-col cols="12" sm="12" md="6">
                <v-text-field
                  v-model="editedItem.description"
                  label="Description"
                  :rules="descriptionRules"
                />
              </v-col>
              <v-col cols="12" sm="12" md="6">
                <v-text-field
                  v-model="editedItem.reward"
                  label="Reward"
                  type="number"
                  step="10"
                  min="0"
                  :rules="positive"
                />
              </v-col>
              <v-col cols="12" sm="12" md="6">
                <v-select
                  :items="questTypes"
                  v-model="editedItem.type"
                  label="Type"
                />
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
import { QUEST_TYPES } from '@/utils/macros/quest-types';
import {
  nameRules,
  descriptionRules,
  positive
} from '@/components/data-tables/validators';

export default {
  name: 'QuestDataDialog',
  mixins: [dataTableDialogMixin],
  data() {
    return {
      emptyItemTemplate: {
        name: '',
        description: '',
        reward: 100,
        type: QUEST_TYPES.BASIC
      },
      nameRules,
      descriptionRules,
      positive,
      formName: 'Quest',
      questTypes: [QUEST_TYPES.BASIC, QUEST_TYPES.EXTRA]
    };
  }
};
</script>
