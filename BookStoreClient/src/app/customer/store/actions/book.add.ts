import { Book } from "../../services";

export class BookAdd {
    static readonly type = '[Book] Add';

    constructor(public book: Book) {}
}
  