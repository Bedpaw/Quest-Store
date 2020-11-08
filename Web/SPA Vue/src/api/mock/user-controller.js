import { mentors, students, users } from '@/mock/user-mock';

const getUsers = () => new Promise(resolve => resolve(users));
const getStudents = () => new Promise(resolve => resolve(students));
const getMentors = () => new Promise(resolve => resolve(mentors));
const getLoggedUser = () => new Promise(resolve => resolve(users[0]));
const addUser = user => new Promise(resolve => resolve(user));
const updateUser = user => new Promise(resolve => resolve(user));
const deleteUser = id => new Promise(resolve => resolve(id));
const updateStudentArtifacts = user => new Promise(resolve => resolve(user));

export const userController = {
  getUsers,
  getLoggedUser,
  addUser,
  updateUser,
  getStudents,
  getMentors,
  // getUser,
  deleteUser,
  // getStudents,
  updateStudentArtifacts
};
