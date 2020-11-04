import {User} from '@/structures/user';
import {ROLES} from '@/utils/macros/roles';
import {artifacts} from '@/mock/artifacts-mock';
import {Mentor} from "@/structures/mentor";
import {classrooms} from "@/mock/classroom-mock";
import {Student} from "@/structures/student";

export const user = {
  name: 'Paweł Bednarczyk',
  role: 'Admin',
  avatar: 'https://randomuser.me/api/portraits/men/81.jpg'
};



export const mentors = [
  new Mentor({
    id: 3,
    name: 'Bruce',
    surname: 'Lee',
    email: 'Bruce@gmail.com',
    role: ROLES.MENTOR,
    image: '',
    classrooms: [
      classrooms[0],
      classrooms[1]
    ]
  }),
  new Mentor({
    id: 5,
    name: 'Jackie',
    surname: 'Chan',
    email: 'Chan@gmail.com',
    role: ROLES.MENTOR,
    image: '',
    classrooms: [
      classrooms[0],
    ]
  })
]

export const students = [
  new Student({
    id: 2,
    name: 'Jan',
    surname: 'Kowalski',
    email: 'kowal@test.com',
    role: ROLES.STUDENT,
    image: '',
    coins: 2000,
    artifacts: [],
    classrooms: [
      classrooms[0],
      classrooms[1]
    ]
  }),
  new Student({
    id: 4,
    name: 'Janek',
    surname: 'Kowalczyk',
    email: 'Kowalczyk@wp.pl',
    role: ROLES.STUDENT,
    image: '',
    coins: 1000,
    artifacts: [],
    classrooms: [
      classrooms[0],
    ]
  }),
]

export const users = [
  new User({
    id: 1,
    name: 'Paweł',
    surname: 'Bednarczyk',
    email: 'bedpaw@test.com',
    description:
      "Hi, I'm Paweł and i want to be full stack developer, my favorite technologies are C#, ASP NET Core and Vue.js",
    role: ROLES.ADMIN,
    image: '/sample',
    coins: 100,
    classrooms: [classrooms[0], classrooms[1]],
    artifacts: [artifacts[0], artifacts[1]]
  }),
  ...students,
  ...mentors
];
