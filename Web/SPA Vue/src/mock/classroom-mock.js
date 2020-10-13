import {Classroom} from "../structures/classroom";
import {ROLES} from "../utils/macros/roles";
import {users} from "./user-mock";

export const classrooms = [
  new Classroom({
    id: 1,
    name: "Web Development 1",
    description: "We love code",
    mentors: users.find(user => user.role === ROLES.MENTOR),
    students: users.filter(user => user.role === ROLES.STUDENT)
  }),
  new Classroom({
    id: 2,
    name: "Web Development 2",
    description: "We love code",
    mentors: users.find(user => user.role === ROLES.MENTOR),
    students: [users.filter(user => user.role === ROLES.STUDENT).pop()]
  })
]
