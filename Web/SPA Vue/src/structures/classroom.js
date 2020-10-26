import { Basic } from './basic';

export class Classroom extends Basic {
  constructor({
    id,
    name,
    description,
    image = '',
    students = [],
    mentors = []
  }) {
    super(id, name, description);
    this.image = image;
    this.mentors = mentors;
    this.students = students;
  }
}
