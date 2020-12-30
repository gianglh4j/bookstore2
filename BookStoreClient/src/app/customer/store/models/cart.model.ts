
import {ICartItem} from './cartitem.model';

export interface ICart {
  CartItems:ICartItem[],
  Amount: number,
  Total:number
}
