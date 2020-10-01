import {User} from "../structures/user";
import {ROLES} from "../utils/macros/roles";

export const user = {
  name: "Paweł Bednarczyk",
  role: "Admin",
  avatar: "https://randomuser.me/api/portraits/men/81.jpg"
}

export const users = [
  new User({
    id: 1,
    name: "Paweł",
    surname: "Bednarczyk",
    email: "bedpaw@test.com",
    role: ROLES.ADMIN,
    image: '',
    accountBalance: 100,
    artifacts: []
  }),
  new User({
    id: 2,
    name: "Jan",
    surname: "Kowalski",
    email: "kowal@test.com",
    role: ROLES.STUDENT,
    image: '',
    accountBalance: 0,
    artifacts: []
  }),
  new User({
    id: 3,
    name: "Bruce",
    surname: "Lee",
    email: "Bruce@gmail.com",
    role: ROLES.MENTOR,
    image: '',
    accountBalance: 0,
    artifacts: []
  }),
  new User({
    id: 4,
    name: "Janek",
    surname: "Kowalczyk",
    email: "Kowalczyk@wp.pl",
    role: ROLES.STUDENT,
    image: '',
    accountBalance:1000,
    artifacts: []
  }),
]
