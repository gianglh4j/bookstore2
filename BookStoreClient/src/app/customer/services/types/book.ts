
import {BookType} from "./booktype";

export interface Book {
    bookId :number,
    bookName: string,
    bookImage: string,
    bookPrice:number,
    isDeleted:boolean,
    bookTypes: BookType[]
}

