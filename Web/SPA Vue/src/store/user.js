import {users} from "@/mock/user-mock";
import {ADD_USER, DELETE_USER, UPDATE_USER} from "@/utils/macros/mutation-types";
import {ROLES} from "@/utils/macros/roles";
import {arrayUtils} from "@/utils/array-utils";

const initialState = {
  users: users,
  loggedUserId: 1
}

export const user = {
  namespaced: true,
  state: initialState,
  getters: {
    // Logged User
    getLoggedUser: (state) => state.users.find(user => user.id === state.loggedUserId),
    getLoggedUserRole: (state, getters) => getters.getLoggedUser.role,

    // Modified Data
    getFullName: () => (user) => user.name + ' ' + user.surname,
    getListOfFullNames: (state, getters) => (usersArray) => usersArray.map(mentor => getters.getFullName(mentor)),
    getUsersFullNameAsString: (state, getters) => (usersArray) => getters.getListOfFullNames(usersArray).join(', '),

    // Filtered Data
    getUserById: (state) => (userId) => state.users.find(user => user.id === parseInt(userId)),
    getUsers: (state) => state.users,
    getStudents: (state) => state.users.filter( user => user.role === ROLES.STUDENT),
    getMentors: (state) => state.users.filter( user => user.role === ROLES.MENTOR),
    getAdmins: (state) => state.users.filter( user => user.role === ROLES.ADMIN),
    getGuests: (state) => state.users.filter( user => user.role === ROLES.GUEST),
  },
  mutations: {
    [ADD_USER] : (state, payload) => state.users.push(payload),
    [UPDATE_USER] : (state, payload) => arrayUtils.updateItem(state.users, payload),
    [DELETE_USER] : (state, payload) => arrayUtils.removeItem(state.users, payload)
  }
}
