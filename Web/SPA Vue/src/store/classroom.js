import {classrooms} from "../mock/classroom-mock";
import {ADD_CLASS} from "../utils/macros/mutation-types";

const initialState = {
  classes : classrooms
}

export const classroom = {
  namespaced: true,
  state: initialState,
  getters: {
    getClasses: (state) => state.classes,
  },
  mutations: {
    [ADD_CLASS] : (state, payload) => state.classes.push(payload),
  }
}
