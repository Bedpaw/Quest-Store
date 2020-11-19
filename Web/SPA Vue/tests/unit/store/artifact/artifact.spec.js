import {ADD_ARTIFACT} from "@/utils/macros/mutation-types";
import {artifact as MArtifact} from "@/store/artifact";

const mutations = MArtifact.mutations

describe("ADD_ARTIFACT", () => {
  it("adds artifact to thr state", () => {
    const ar = { id: 1, name: "Artifact" }
    const state = {
      artifacts: []
    }
    mutations.ADD_ARTIFACT(state, ar)

    expect(state).toEqual({
      artifacts: [{id: 1, name: "Artifact"}]
    })
  })
})
