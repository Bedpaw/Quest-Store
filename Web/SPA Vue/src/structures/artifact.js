import { Basic } from './basic';

export class Artifact extends Basic {
  constructor({
    id = null,
    name = '',
    description = '',
    image = '',
    cost = 50,
    quantity = 50
    // groupPurchasePossible= false,
    //depositedMoney= 0
  }) {
    super(id, name, description);
    this.image = image;
    this.cost = cost;
    this.quantity = quantity;
    //this.groupPurchasePossible = groupPurchasePossible
    //this.depositedMoney = depositedMoney
  }
}
