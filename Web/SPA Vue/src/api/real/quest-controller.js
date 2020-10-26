import axios from 'axios'
import {MAP_QUEST_TYPE} from "@/utils/macros/quest-types";


const url = "https://localhost:5001/api/Quests"


const getQuests = async () => {
  try {
    const response = await axios.get(url);
    console.log(response.data)
    response.data.map(quest => quest.type = MAP_QUEST_TYPE[quest.type])
    return response.data
  } catch (error) {
    console.log(error)
    return error
  }
}
const addQuest = async (quest) => {
  try {
    console.log(quest)
    const response = await axios.post(url, ({
      name: quest.name,
      description: quest.description,
      image: quest.image,
      reward: quest.reward,
      type: quest.type
    }))
    console.log(response)
    return response.data


  } catch (error) {
    console.log(error)
  }
}
const updateQuest = async (quest) => {
  try {
    const response = await axios.put(url + `/${quest.id}`, ({
      name: quest.name,
      description: quest.description,
      image: quest.image,
      reward: quest.reward,
      type: quest.type
    }))
    console.log(response)
    return response.data


  } catch (error) {
    console.log(error)
  }
}
const deleteQuest = async (id) => {
  try {
    const response = await axios.delete(url + `/${id}`)
    return response.data
  } catch (error) {
    return error
  }
}

export const questController = {
  getQuests,
  addQuest,
  updateQuest,
  deleteQuest
}
