import {Classroom} from '@/structures/classroom';

export const classrooms = [
  new Classroom({
    id: 1,
    name: 'Web Development 1',
    description: 'We love code',
    mentors: [
      {
        id: 3,
        name: 'Bruce',
        surname: 'Lee',
        email: 'Bruce@gmail.com',
      },
      {
        id: 5,
        name: 'Jackie',
        surname: 'Chan',
        email: 'Chan@gmail.com',
      },
    ],
    students: [
      {
        id: 2,
        name: 'Jan',
        surname: 'Kowalski',
        email: 'kowal@test.com',
      },
      {
        id: 4,
        name: 'Janek',
        surname: 'Kowalczyk',
        email: 'Kowalczyk@wp.pl',
      }
    ]
  }),
  new Classroom({
    id: 2,
    name: 'Web Development 2',
    description: 'We love code',
    mentors: [
      {
        id: 3,
        name: 'Bruce',
        surname: 'Lee',
        email: 'Bruce@gmail.com',
      },
    ],
    students: [
      {
        id: 2,
        name: 'Jan',
        surname: 'Kowalski',
        email: 'kowal@test.com',
      },
    ]
  })
];
