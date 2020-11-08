import { Basic } from './basic';
import { ROLES } from '@/utils/macros/roles';

export class Mentor extends Basic {
  constructor({
    id,
    name,
    description,
    surname = '',
    email = '',
    role = ROLES.MENTOR,
    image = '',
    classrooms = []
  }) {
    super(id, name, description);
    this.classrooms = classrooms;
    this.role = role;
    this.image = image;
    this.email = email;
    this.surname = surname;
  }
}
