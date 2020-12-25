interface BookType {
    bookTypeId: number, bookTypeName: string
}

export interface Book {
    bookId :number,
    bookName: string,
    bookImage: string,
    bookPrice:number,
    isDeleted:boolean,
    bookTypes: BookType[]

}

