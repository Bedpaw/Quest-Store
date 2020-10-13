import {arrayUtils} from "@/utils/array-utils";
import {ADD_ARTIFACT, DELETE_ARTIFACT, UPDATE_ARTIFACT} from "@/utils/macros/mutation-types";

const initialState = {
  artifacts: []
}

export const artifact = {
  namespaced: true,
  state: initialState,
  getters: {
    getArtifacts: (state) => state.artifacts,
  },
  mutations: {
    [ADD_ARTIFACT]: (state, payload) => state.artifacts.push(payload),
    [UPDATE_ARTIFACT]: (state, payload) => arrayUtils.updateItem(state.artifacts, payload),
    [DELETE_ARTIFACT]: (state, payload) => arrayUtils.removeItem(state.artifacts, payload)
  }
}

