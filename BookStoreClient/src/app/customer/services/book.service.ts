import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {  throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Book } from './types';

@Injectable({
  providedIn: 'root'
})
export class BookService {

 // private apiServer = "https://localhost:44333";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) {}

  createBook(book:Book): Observable<Book> {
    return this.httpClient.post<Book>( '/api/books/', JSON.stringify(book), this.httpOptions)
 
  }

  getBookById(id:number): Observable<Book> {
    return this.httpClient.get<Book>('/api/books/' + id)
   
  }

  getBookByType(id:number): Observable<Book[]> {
    return this.httpClient.get<Book[]>('/api/books/types/' + id).pipe(
      catchError(this.errorHandler)
    )
   
  }

  getAll(): Observable<Book[]> {
    return this.httpClient.get<Book[]>('/api/books/').pipe(
      catchError(this.errorHandler)
    )
  
  }

  update(id:number, book:Book): Observable<Book> {
    return this.httpClient.put<Book>('/api/books/' + id, JSON.stringify(book), this.httpOptions)
  }

  delete(book:Book){
    
    return this.httpClient.post<Book>('/api/books/delete/' + book.bookId, JSON.stringify(book), this.httpOptions)

  }
  errorHandler(error:any) {
     let errorMessage = '';
     if(error.error instanceof ErrorEvent) {
       // Get client-side error
       errorMessage = error.error.message;
     } else {
       // Get server-side error
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     console.log(errorMessage);
     return throwError(errorMessage);
  }

}
