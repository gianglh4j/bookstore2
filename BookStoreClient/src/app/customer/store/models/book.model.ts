import {IBookType} from './booktype.model';

export interface IBook {
    bookId :number,
    bookName: string,
    bookImage: string,
    bookPrice:number,
    isDeleted:boolean,
    bookTypes: IBookType[]
}

