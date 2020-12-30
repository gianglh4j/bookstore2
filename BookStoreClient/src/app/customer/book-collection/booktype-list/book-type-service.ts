import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {BookType} from '../../services';
import {  throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookTypeService {

 // private apiServer = "https://localhost:44333";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) {   }



  getAll(): Observable<BookType[]> {
    return this.httpClient.get<BookType[]>('/api/booktypes')
    .pipe(
        catchError(this.errorHandler)
      )
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
