import {IBook} from '../models'

export class DecreaseItemCart {
    static readonly type = '[Cart] Decrease';

    constructor(public book: IBook) {}
}
  