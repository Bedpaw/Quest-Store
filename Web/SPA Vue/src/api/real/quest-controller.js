import axios from 'axios'
import {MAP_QUEST_TYPE} from "@/utils/macros/quest-types";


const url = "https://localhost:5001/api/Quests"

const getQuests = async () => {
  try {
    const response = await axios.get(url);
    console.log(response.data)
    response.data.map(quest => quest.type = MAP_QUEST_TYPE[quest.type])
    return response.data
  } catch (error){
    console.log(error)
    return error
  }
}

export const questController = {
  getQuests
}
