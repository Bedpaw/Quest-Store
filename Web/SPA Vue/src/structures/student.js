import { Basic } from './basic';
import { ROLES } from '@/utils/macros/roles';

export class Student extends Basic {
  constructor({
    id,
    name,
    description,
    surname = '',
    email = '',
    role = ROLES.STUDENT,
    image = '',
    coins = 0,
    artifacts = [],
    classrooms = []
  }) {
    super(id, name, description);
    this.classrooms = classrooms;
    this.role = role;
    this.image = image;
    this.coins = coins;
    this.email = email;
    this.surname = surname;
    this.artifacts = artifacts;
  }
}
