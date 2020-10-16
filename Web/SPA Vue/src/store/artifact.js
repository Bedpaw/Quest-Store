import {arrayUtils} from "@/utils/array-utils";
import {ADD_ARTIFACT, BUY_ARTIFACT, DELETE_ARTIFACT, UPDATE_ARTIFACT} from "@/utils/macros/mutation-types";
import {artifacts} from "@/mock/artifacts-mock";

const initialState = {
  artifacts: artifacts
}

export const artifact = {
  namespaced: true,
  state: initialState,
  getters: {
    getArtifacts: (state) => state.artifacts,
    getArtifactById: (state) => (artifactId) => state.artifacts.find(artifact => artifact.id === parseInt(artifactId)),
  },
  mutations: {
    [ADD_ARTIFACT]: (state, payload) => state.artifacts.push(payload),
    [UPDATE_ARTIFACT]: (state, payload) => arrayUtils.updateItem(state.artifacts, payload),
    [DELETE_ARTIFACT]: (state, payload) => arrayUtils.removeItem(state.artifacts, payload),
    [BUY_ARTIFACT]: (state, artifactId) => {
      const purchasedArtifact = state.artifacts.find(artifact => artifact.id === parseInt(artifactId))
      purchasedArtifact.quantity--
    }

  }
}
