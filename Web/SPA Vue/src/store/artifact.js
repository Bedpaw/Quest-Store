import { arrayUtils } from '@/utils/array-utils';
import {
  ADD_ARTIFACT,
  BUY_ARTIFACT,
  DELETE_ARTIFACT,
  FETCH_ARTIFACTS,
  PUSH_ARTIFACT,
  UPDATE_ARTIFACT
} from '@/utils/macros/mutation-types';
import { api } from '@/api';
import { Artifact } from '@/structures/artifact';
import { storeActions } from '@/utils/store-utils';

export const artifact = {
  namespaced: true,
  state: {
    artifacts: []
  },
  getters: {
    getArtifacts: state => state.artifacts,
    getArtifactById: state => artifactId =>
      state.artifacts.find(artifact => artifact.id === parseInt(artifactId))
  },
  mutations: {
    [FETCH_ARTIFACTS]: (state, payload) => (state.artifacts = payload),
    [ADD_ARTIFACT]: (state, payload) => state.artifacts.push(payload),
    [UPDATE_ARTIFACT]: (state, payload) =>
      arrayUtils.updateItem(state.artifacts, payload),
    [DELETE_ARTIFACT]: (state, payload) =>
      arrayUtils.removeItem(state.artifacts, payload),
    [BUY_ARTIFACT]: (state, artifactId) => {
      const purchasedArtifact = state.artifacts.find(
        artifact => artifact.id === parseInt(artifactId)
      );
      if (purchasedArtifact.quantity !== null) purchasedArtifact.quantity--;
    }
  },
  actions: {
    fetchArtifacts: storeActions.fetchResources(
      api.artifactController.getArtifacts,
      FETCH_ARTIFACTS,
      Artifact
    ),
    addArtifact: storeActions.addResource(
      api.artifactController.addArtifact,
      ADD_ARTIFACT,
      Artifact
    ),
    updateArtifact: storeActions.updateResource(
      api.artifactController.updateArtifact,
      UPDATE_ARTIFACT,
      Artifact
    ),
    deleteArtifact: storeActions.deleteResource(
      api.artifactController.deleteArtifact,
      DELETE_ARTIFACT
    ),
    buyArtifact({ commit }, { user, artifact }) {
      const enoughOrUnlimitedArtifacts =
        artifact.quantity === null || artifact.quantity > 0;
      if (user.coins >= artifact.cost && enoughOrUnlimitedArtifacts) {
        commit(BUY_ARTIFACT, artifact.id);
        commit('user/' + PUSH_ARTIFACT, { user, artifact }, { root: true });
      }
    }
  }
};
