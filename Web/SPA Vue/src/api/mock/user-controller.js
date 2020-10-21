import {users} from "@/mock/user-mock";


const getUsers = () => users
const getLoggedUser = () => users[0]

export const userController = {
  getUsers,
  getLoggedUser
}
