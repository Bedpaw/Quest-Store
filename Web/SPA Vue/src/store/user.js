import { users } from '@/mock/user-mock';
import {
  ADD_USER,
  DELETE_USER,
  FETCH_LOGGED_USER,
  FETCH_MENTORS,
  FETCH_STUDENTS,
  FETCH_USERS,
  PUSH_ARTIFACT,
  UPDATE_USER
} from '@/utils/macros/mutation-types';
import { arrayUtils } from '@/utils/array-utils';
import { api } from '@/api';
import { User } from '@/structures/user';
import { storeActions } from '@/utils/store-utils';
import { Student } from '@/structures/student';
import { Mentor } from '@/structures/mentor';
import { createUser } from '@/utils/structures-utils';

export const user = {
  namespaced: true,
  state: {
    users: [],
    students: [],
    mentors: [],
    loggedUser: {}
  },
  getters: {
    // For test only // that should be mutation
    changeToUserWithRole: state => role => {
      state.loggedUser = users.find(user => user.role === role);
    },

    // Logged User
    getLoggedUser: state => state.loggedUser,
    getLoggedUserRole: state => state.loggedUser.role,

    // Modified Data
    getFullName: () => user => user.name + ' ' + user.surname,
    getListOfFullNames: (state, getters) => usersArray => {
      if (usersArray === null) return [];
      return usersArray.map(mentor => getters.getFullName(mentor));
    },
    getUsersFullNameAsString: (state, getters) => usersArray =>
      getters.getListOfFullNames(usersArray).join(', '),
    getUsersAsFullNameAndDataFormat: (state, getters) => usersArray =>
      usersArray.map(user => {
        return {
          text: getters.getFullName(user),
          value: user
        };
      }),

    getThisUserRoleArray: state => user => {
      return {
        ADMIN: state.users,
        STUDENT: state.students,
        MENTOR: state.mentors
      }[user.role];
    },

    // Filtered Data
    getUserById: state => userId => {
      let user = state.students.find(user => user.id === parseInt(userId));
      if (user) return user;

      user = state.mentors.find(user => user.id === parseInt(userId));
      if (user) return user;

      user = state.users.find(user => user.id === parseInt(userId));
      return user;
    },

    getUsers: state => state.users,
    getStudents: state => state.students,
    getMentors: state => state.mentors
  },
  mutations: {
    [FETCH_LOGGED_USER]: (state, payload) => (state.loggedUser = payload),
    [FETCH_USERS]: (state, payload) => (state.users = payload),
    [FETCH_STUDENTS]: (state, payload) => (state.students = payload),
    [FETCH_MENTORS]: (state, payload) => (state.mentors = payload),

    [ADD_USER]: (state, { user, userArray }) => {
      userArray.push(user);
    },

    [UPDATE_USER]: (state, { user, userArray }) =>
      arrayUtils.updateItem(userArray, user),

    [DELETE_USER]: (state, { user, userArray }) =>
      arrayUtils.removeItem(userArray, user),

    [PUSH_ARTIFACT]: (state, { user, artifact }) => {
      user.coins -= artifact.cost;
      user.artifacts.push(artifact);
    }
  },
  actions: {
    fetchUsers: storeActions.fetchResources(api.getUsers, FETCH_USERS, User),
    fetchStudents: storeActions.fetchResources(
      api.getStudents,
      FETCH_STUDENTS,
      Student
    ),
    fetchMentors: storeActions.fetchResources(
      api.getMentors,
      FETCH_MENTORS,
      Mentor
    ),

    async fetchLoggedUser({ commit }) {
      const user = await api.getLoggedUser();
      commit(FETCH_LOGGED_USER, createUser(user));
    },
    async addUser({ commit }, { user, userArray }) {
      await api.addUser(user).then(resource =>
        commit(ADD_USER, {
          user: createUser(resource),
          userArray
        })
      );
    },
    async updateUser({ commit }, { user, userArray }) {
      await api.updateUser(user).then(resource =>
        commit(UPDATE_USER, {
          user: createUser(resource),
          userArray
        })
      );
    },
    async deleteUser({ commit }, { user, userArray }) {
      await api.deleteUser(user.id).then(
        commit(DELETE_USER, {
          user,
          userArray
        })
      );
    }
  }
};
