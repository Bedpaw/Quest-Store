import { quests } from '@/mock/quests-mock';

const getQuests = () => new Promise(resolve => resolve(quests));
const addQuest = quest => new Promise(resolve => resolve(quest));
const updateQuest = quest => new Promise(resolve => resolve(quest));
const deleteQuest = id => new Promise(resolve => resolve(id));

export const questController = {
  getQuests,
  addQuest,
  updateQuest,
  deleteQuest
};
