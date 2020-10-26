import { users } from '@/mock/user-mock';

const getUsers = () => new Promise(resolve => resolve(users));
const getLoggedUser = () => users[0];

export const userController = {
  getUsers,
  getLoggedUser
};
