import {Basic} from "./basic";

export class Classroom extends Basic {
  constructor(
    { id,
      name,
      description,
      image= '',
      students=[],
      mentor= {},
    }) {
    super(id, name, description);
    this.image = image
    this.mentor = mentor
    this.students = students
  }
}
