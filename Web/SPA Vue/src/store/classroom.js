import {arrayUtils} from "@/utils/array-utils";
import {
  ADD_CLASS,
  DELETE_CLASS,
  FETCH_CLASSES,
  UPDATE_CLASS,
} from "@/utils/macros/mutation-types";
import {api} from "@/api";
import {Classroom} from "@/structures/classroom";
import {storeActions} from "@/utils/store-utils";


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
    [FETCH_CLASSES]: (state, payload) => state.classes = payload,
    [ADD_CLASS]: (state, payload) => state.classes.push(payload),
    [UPDATE_CLASS]: (state, payload) => arrayUtils.updateItem(state.classes, payload),
    [DELETE_CLASS]: (state, payload) => arrayUtils.removeItem(state.classes, payload)
  },
  actions: {
    fetchClasses: storeActions.fetchResources(api.classroomController.getClassrooms, FETCH_CLASSES, Classroom),
    addClassroom: storeActions.addResource(api.classroomController.addClassroom, ADD_CLASS, Classroom),
    updateClassroom: storeActions.updateResource(api.classroomController.updateClassroom, UPDATE_CLASS, Classroom),
    deleteClassroom: storeActions.deleteResource(api.classroomController.deleteClassroom, DELETE_CLASS),
  }
}
