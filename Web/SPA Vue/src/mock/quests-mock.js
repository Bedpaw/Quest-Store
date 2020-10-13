import {Quest} from "@/structures/quest";
import {QUEST_TYPES} from "@/utils/macros/quest-types";


export const quests = [
  new Quest({
    id: 1,
    name: "Write 100 lines of code",
    image: '',
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet porta ligula et efficitur. Proin dictum, metus non dapibus viverra, sapien purus pretium dui, et congue arcu turpis et tortor.",
    reward: 200,
    type: QUEST_TYPES.BASIC
  }),
  new Quest({
    id: 2,
    name: "Write 10000 lines of code",
    image: '',
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet porta ligula et efficitur. Proin dictum, metus non dapibus viverra, sapien purus pretium dui, et congue arcu turpis et tortor.",
    reward: 500,
    type: QUEST_TYPES.BASIC
  }),
  new Quest({
    id: 3,
    name: "Find bug in Curriculum",
    image: '',
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet porta ligula et efficitur. Proin dictum, metus non dapibus viverra, sapien purus pretium dui, et congue arcu turpis et tortor.",
    reward: 50,
    type: QUEST_TYPES.EXTRA
  }),
  new Quest({
    id: 4,
    name: "Create tutorial for other students",
    image: '',
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque aliquet porta ligula et efficitur. Proin dictum, metus non dapibus viverra, sapien purus pretium dui, et congue arcu turpis et tortor.",
    reward: 1000,
    type: QUEST_TYPES.EXTRA
  })

]

