import {State, Action, StateContext, Selector} from '@ngxs/store';
import {tap} from 'rxjs/operators';

import {
    BookAdd,
    BookGetAll
} from './actions';

import { IBook } from './models';
import { BookService } from '../services';
import { Injectable } from '@angular/core';


export interface BookStateModel {
    books: IBook[];
    selectedCategory: number;
}

@State<BookStateModel>({
    name: 'book',
    defaults: {
        books: [],
        selectedCategory: 0
    }
})

@Injectable()
export class BookState {

    constructor(private bookService: BookService) {
    }

    @Selector()
    static getBooksList(state: BookStateModel): IBook[] {
        return state.books;
    }

    @Selector()
    static getSelectedCategory(state: BookStateModel): number {
        return state.selectedCategory;
    }

    @Action(BookGetAll)
    getBooks({getState, setState}: StateContext<BookStateModel>) {
        return this.bookService.getAll().pipe(tap((result) => {
            const state = getState();
            setState({
                ...state,
                books: result,
            });
        }));
    }
    // @Action(GetBooksByType)
    // getBooksByType({getState, setState}: StateContext<BookStateModel>,{id} : GetBooksByType) {
    //     return this.bookService.getBookByType(id).pipe(tap((result) => {
    //         const state = getState();
    //         setState({
    //             ...state,
    //             books: result,
    //         });
    //     }));
    // }

    @Action(BookAdd)
    addBook({getState, patchState}: StateContext<BookStateModel>, {book}: BookAdd) {
        return this.bookService.createBook(book).pipe(tap((result) => {
            const state = getState();
            patchState({
                books: [...state.books, result]
            });
        }));
    }

    // @Action(UpdateBook)
    // updateBook({getState, setState}: StateContext<BookStateModel>, {payload, id}: UpdateBook) {
    //     return this.bookService.update(id,payload).pipe(tap((result) => {
    //         const state = getState();
    //         const bookList = [...state.books];
    //         const bookIndex = bookList.findIndex(item => item.bookId === id);
    //         bookList[bookIndex] = result;
    //         setState({
    //             ...state,
    //             books: bookList,
    //         });
    //     }));
    // }


    // @Action(DeleteBook)
    // deleteTodo({getState, setState}: StateContext<BookStateModel>, {payload}: DeleteBook) {
    //     return this.bookService.delete(payload).pipe(tap((result) => {
    //         const state = getState();
    //         const filteredArray = state.books.filter(item => item.bookId !== result.bookId);
    //         setState({
    //             ...state,
    //             books: filteredArray,
    //         });
    //     }));
    // }

}
