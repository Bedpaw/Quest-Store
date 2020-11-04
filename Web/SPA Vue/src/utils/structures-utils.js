import {User} from "@/structures/user";
import {Student} from "@/structures/student";
import {Mentor} from "@/structures/mentor";

const getUserConstructor = (user) => {
  return {
    ADMIN: User,
    STUDENT: Student,
    MENTOR: Mentor
  }[user.role]
}

export const createUser = (user) => {
  const constructor = getUserConstructor(user)
  return new constructor(user)
}
