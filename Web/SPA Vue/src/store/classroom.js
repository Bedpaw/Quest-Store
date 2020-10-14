import {classrooms} from "../mock/classroom-mock";
import {ADD_CLASS, } from "../utils/macros/mutation-types";
import {arrayUtils} from "@/utils/array-utils";
import {DELETE_CLASS, UPDATE_CLASS} from "@/utils/macros/mutation-types";

const initialState = {
  classes : classrooms
}

export const classroom = {
  namespaced: true,
  state: initialState,
  getters: {
    getClasses: (state) => state.classes,
    getClassById: (state) => (_classId) => state.classes.filter(_class => _class.id === parseInt(_classId)),
    getClassesByUserId: (state) => (userId) => state.classes.filter(_class => _class.students.find(user => user.id === userId))
  },
  mutations: {
    [ADD_CLASS] : (state, payload) => state.classes.push(payload),
    [UPDATE_CLASS] : (state, payload) => arrayUtils.updateItem(state.classes, payload),
    [DELETE_CLASS] : (state, payload) => arrayUtils.removeItem(state.classes, payload)
  }
}
