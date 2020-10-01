import {Basic} from "./basic";
import {ROLES} from "../utils/macros/roles";

export class User extends Basic{
  constructor(
    { id, name, description, surname = '', email = '', role = ROLES.GUEST,
      image = '', accountBalance = 0, artifacts = [] }) {

    super(id, name, description);

    this.role = role;
    this.image = image;
    this.accountBalance = accountBalance;
    this.email = email;
    this.surname = surname
    this.artifacts = artifacts;
  };
  getFullName = () => this.name + " " + this.surname
}

