import { arrayUtils } from '@/utils/array-utils';
import {
  ADD_QUEST,
  DELETE_QUEST,
  FETCH_QUESTS,
  UPDATE_QUEST
} from '@/utils/macros/mutation-types';
import { QUEST_TYPES } from '@/utils/macros/quest-types';
import { api } from '@/api';
import { Quest } from '@/structures/quest';
import { storeActions } from '@/utils/store-utils';

export const quest = {
  namespaced: true,
  state: {
    quests: []
  },
  getters: {
    getQuests: state => state.quests,
    getQuestById: state => questId =>
      state.quests.find(quest => quest.id === parseInt(questId)),
    getBasicQuests: state =>
      state.quests.filter(quest => quest.type === QUEST_TYPES.BASIC),
    getExtraQuests: state =>
      state.quests.filter(quest => quest.type === QUEST_TYPES.EXTRA)
  },
  mutations: {
    [FETCH_QUESTS]: (state, payload) => (state.quests = payload),
    [ADD_QUEST]: (state, payload) => state.quests.push(payload),
    [UPDATE_QUEST]: (state, payload) =>
      arrayUtils.updateItem(state.quests, payload),
    [DELETE_QUEST]: (state, payload) =>
      arrayUtils.removeItem(state.quests, payload)
  },
  actions: {
    fetchQuests: storeActions.fetchResources(
      api.questController.getQuests,
      FETCH_QUESTS,
      Quest
    ),
    addQuest: storeActions.addResource(
      api.questController.addQuest,
      ADD_QUEST,
      Quest
    ),
    updateQuest: storeActions.updateResource(
      api.questController.updateQuest,
      UPDATE_QUEST,
      Quest
    ),
    deleteQuest: storeActions.deleteResource(
      api.questController.deleteQuest,
      DELETE_QUEST
    )
  }
};
