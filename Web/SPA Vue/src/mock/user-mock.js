import { User } from '@/structures/user';
import { ROLES } from '@/utils/macros/roles';
import { artifacts } from '@/mock/artifacts-mock';

export const user = {
  name: 'Paweł Bednarczyk',
  role: 'Admin',
  avatar: 'https://randomuser.me/api/portraits/men/81.jpg'
};

export const users = [
  new User({
    id: 1,
    name: 'Paweł',
    surname: 'Bednarczyk',
    email: 'bedpaw@test.com',
    description:
      "Hi, I'm Paweł and i want to be full stack developer, my favorite technologies are C#, ASP NET Core and Vue.js",
    role: ROLES.ADMIN,
    image: '',
    coins: 100,
    artifacts: [artifacts[0], artifacts[1]]
  }),
  new User({
    id: 2,
    name: 'Jan',
    surname: 'Kowalski',
    email: 'kowal@test.com',
    role: ROLES.STUDENT,
    image: '',
    coins: 0,
    artifacts: []
  }),
  new User({
    id: 3,
    name: 'Bruce',
    surname: 'Lee',
    email: 'Bruce@gmail.com',
    role: ROLES.MENTOR,
    image: '',
    coins: 0,
    artifacts: []
  }),

  new User({
    id: 4,
    name: 'Janek',
    surname: 'Kowalczyk',
    email: 'Kowalczyk@wp.pl',
    role: ROLES.STUDENT,
    image: '',
    coins: 1000,
    artifacts: []
  }),
  new User({
    id: 5,
    name: 'Jackie',
    surname: 'Chan',
    email: 'Chan@gmail.com',
    role: ROLES.MENTOR,
    image: '',
    coins: 0,
    artifacts: []
  })
];
export const loggedUser = users[0];
