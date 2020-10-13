import {users} from "@/mock/user-mock";
import {ADD_USER, DELETE_USER, UPDATE_USER} from "@/utils/macros/mutation-types";
import {ROLES} from "@/utils/macros/roles";
import {arrayUtils} from "@/utils/array-utils";

const initialState = {
  users: users
}

export const user = {
  namespaced: true,
  state: initialState,
  getters: {
    getUsers: (state) => state.users,
    getStudents: (state) => state.users.map( user => user.role === ROLES.STUDENT),
    getMentors: (state) => state.users.map( user => user.role === ROLES.MENTOR),
    getAdmins: (state) => state.users.map( user => user.role === ROLES.ADMIN),
    getGuests: (state) => state.users.map( user => user.role === ROLES.GUEST),
  },
  mutations: {
    [ADD_USER] : (state, payload) => state.users.push(payload),
    [UPDATE_USER] : (state, payload) => arrayUtils.updateItem(state.users, payload),
    [DELETE_USER] : (state, payload) => arrayUtils.removeItem(state.users, payload)
  }
}
