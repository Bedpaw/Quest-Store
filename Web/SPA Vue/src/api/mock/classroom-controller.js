import { classrooms } from '@/mock/classroom-mock';

const getClassrooms = () => new Promise(resolve => resolve(classrooms));

export const classroomController = {
  getClassrooms
};
