import {quests} from "@/mock/quests-mock";


const getQuests = () => new Promise((resolve => resolve(quests) ))

export const questController = {
  getQuests
}
