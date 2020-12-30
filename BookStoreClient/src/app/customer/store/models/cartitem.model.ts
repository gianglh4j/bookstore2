
import { IBook } from "./book.model";

export interface ICartItem {
  book:IBook,
  quantity: number;
}
