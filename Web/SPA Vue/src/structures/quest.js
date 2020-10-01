import {Basic} from "./basic";
import {QUEST_TYPES} from "../utils/macros/quest-types";

export class Quest extends Basic {
  constructor(image='', prize=100, type=QUEST_TYPES.BASIC) {
    super();
    this.image = image
    this.prize = prize
    this.type = type
  }
}
