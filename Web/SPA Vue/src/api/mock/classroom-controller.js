import { classrooms } from '@/mock/classroom-mock';

const getClassrooms = () => new Promise(resolve => resolve(classrooms));
const addClassroom = classroom => new Promise(resolve => resolve(classroom))
const updateClassroom = classroom => new Promise(resolve => resolve(classroom))
const deleteClassroom = id => new Promise(resolve => resolve(id))
const performGroupPurchase = (classroom, artifact) => new Promise(resolve => {resolve({classroom, artifact})})

export const classroomController = {
  getClassrooms,
  addClassroom,
  updateClassroom,
  deleteClassroom,
  performGroupPurchase
};
