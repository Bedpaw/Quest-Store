import {users} from "@/mock/user-mock";
import {
  ADD_USER,
  DELETE_USER,
  FETCH_LOGGED_USER,
  FETCH_USERS,
  PUSH_ARTIFACT,
  UPDATE_USER
} from "@/utils/macros/mutation-types";
import {ROLES} from "@/utils/macros/roles";
import {arrayUtils} from "@/utils/array-utils";
import {api} from "@/api";
import {User} from "@/structures/user";
import {storeActions} from "@/utils/store-utils";

export const user = {
  namespaced: true,
  state: {
    users: [],
    loggedUser: {}
  },
  getters: {
    // For test only // that should be mutation
    changeToUserWithRole: (state) => (role) => {
      const userWithRole = users.find(user => user.role === role)
      state.loggedUser = userWithRole
    },

    // Logged User
    getLoggedUser: (state) => state.loggedUser,
    getLoggedUserRole: (state) => state.loggedUser.role,

    // Modified Data
    getFullName: () => (user) => user.name + ' ' + user.surname,
    getListOfFullNames: (state, getters) => (usersArray) => usersArray.map(mentor => getters.getFullName(mentor)),
    getUsersFullNameAsString: (state, getters) => (usersArray) => getters.getListOfFullNames(usersArray).join(', '),
    getUsersAsFullNameAndDataFormat: (state, getters) => (usersArray) => usersArray.map(user => {
      return {
        text: getters.getFullName(user),
        value: user
      }
    }),

    // Filtered Data
    getUserById: (state) => (userId) => state.users.find(user => user.id === parseInt(userId)),
    getUsers: (state) => state.users,
    getStudents: (state) => state.users.filter(user => user.role === ROLES.STUDENT),
    getMentors: (state) => state.users.filter(user => user.role === ROLES.MENTOR),
    getAdmins: (state) => state.users.filter(user => user.role === ROLES.ADMIN),
    getGuests: (state) => state.users.filter(user => user.role === ROLES.GUEST),
  },
  mutations: {
    [ADD_USER]: (state, payload) => state.users.push(payload),
    [FETCH_LOGGED_USER]: (state, payload) => state.loggedUser = payload,
    [FETCH_USERS]: (state, payload) => state.users = payload,
    [UPDATE_USER]: (state, payload) => arrayUtils.updateItem(state.users, payload),
    [DELETE_USER]: (state, payload) => arrayUtils.removeItem(state.users, payload),
    [PUSH_ARTIFACT]: (state, {user, artifact}) => {
      user.coins -= artifact.cost
      user.artifacts.push(artifact)
    },
  },
  actions: {
    fetchUsers: storeActions.fetchResources(api.getUsers, FETCH_USERS, User),
    addUser: storeActions.addResource(api.addUser, ADD_USER, User),
    updateUser: storeActions.updateResource(api.updateUser, UPDATE_USER, User),
    deleteUser: storeActions.deleteResource(api.deleteUser, DELETE_USER),

    async fetchLoggedUser({commit}) {
      const user = await api.getLoggedUser()
      commit(FETCH_LOGGED_USER, new User(user))
    },
  }
}
