import {arrayUtils} from "@/utils/array-utils";
import {ADD_QUEST, DELETE_QUEST, UPDATE_QUEST} from "@/utils/macros/mutation-types";
import {quests} from "@/mock/quests-mock";
import {QUEST_TYPES} from "@/utils/macros/quest-types";

const initialState = {
  quests: quests
}

export const quest = {
  namespaced: true,
  state: initialState,
  getters: {
    getQuests: (state) => state.quests,
    getBasicQuests: (state) => state.quests.filter(quest => quest.type === QUEST_TYPES.BASIC),
    getExtraQuests: (state) => state.quests.filter(quest => quest.type === QUEST_TYPES.EXTRA),
  },
  mutations: {
    [ADD_QUEST] : (state, payload) => state.quests.push(payload),
    [UPDATE_QUEST] : (state, payload) => arrayUtils.updateItem(state.quests, payload),
    [DELETE_QUEST] : (state, payload) => arrayUtils.removeItem(state.quests, payload)
  }
}
