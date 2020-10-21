import {arrayUtils} from "@/utils/array-utils";
import {ADD_CLASS, DELETE_CLASS, FETCH_CLASSES, UPDATE_CLASS} from "@/utils/macros/mutation-types";
import {api} from "@/api";
import {Classroom} from "@/structures/classroom";


export const classroom = {
  namespaced: true,
  state: {
    classes: []
  },
  getters: {
    getClasses: (state) => state.classes,
    getClassById: (state) => (_classId) => state.classes.find(_class => _class.id === parseInt(_classId)),
    getClassesByUserId: (state) => (userId) => state.classes.filter(_class => _class.students.find(user => user.id === userId))
  },
  mutations: {
    [FETCH_CLASSES] : (state, payload) => state.classes = payload,
    [ADD_CLASS] : (state, payload) => state.classes.push(payload),
    [UPDATE_CLASS] : (state, payload) => arrayUtils.updateItem(state.classes, payload),
    [DELETE_CLASS] : (state, payload) => arrayUtils.removeItem(state.classes, payload)
  },
  actions: {
    async fetchClasses ({commit}) {
      const classrooms = await api.classroomController
        .getClassrooms()
        .then(classrooms => classrooms.map(classroom => new Classroom(classroom)))
      commit(FETCH_CLASSES, classrooms)
    }
  }
}
