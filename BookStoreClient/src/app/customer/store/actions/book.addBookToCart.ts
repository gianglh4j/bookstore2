import { Book } from "../../services";

export class AddBookToCart {
    static readonly type = '[BookList]  Add To Cart';

    constructor(public book: Book) {}
}
  