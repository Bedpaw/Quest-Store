import {Basic} from "./basic";
import {QUEST_TYPES} from "../utils/macros/quest-types";

export class Quest extends Basic {
  constructor({
    id,
    name,
    description,
    image= '',
    reward= 100,
    type= QUEST_TYPES.BASIC}) {
    super(id, name, description);
    this.image = image
    this.reward = reward
    this.type = type
  }
}
