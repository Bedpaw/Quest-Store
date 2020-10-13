import {arrayUtils} from "@/utils/array-utils";
import {ADD_QUEST, DELETE_QUEST, UPDATE_QUEST} from "@/utils/macros/mutation-types";
import {quests} from "@/mock/quests-mock";

const initialState = {
  quests: quests
}

export const quest = {
  namespaced: true,
  state: initialState,
  getters: {
    getQuests: (state) => state.quests,
  },
  mutations: {
    [ADD_QUEST] : (state, payload) => state.quests.push(payload),
    [UPDATE_QUEST] : (state, payload) => arrayUtils.updateItem(state.quests, payload),
    [DELETE_QUEST] : (state, payload) => arrayUtils.removeItem(state.quests, payload)
  }
}
