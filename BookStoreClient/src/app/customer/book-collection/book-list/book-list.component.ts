import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {Select, Store} from '@ngxs/store'
import {AddBookToCart} from '../../store'
import { 
  BookTypeState,
  IBook,
  BookGetAll,
} from '../../store';
import { Book, BookService } from '../../services';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss'],
  
})
export class BookListComponent implements OnInit {

  books$:IBook[] = [];
 


 
  constructor(private store: Store, public bookService: BookService) {
      
  }

  
  ngOnInit(): void {
    

    // var a = this.store.select(BookTypeState.getSelectedCategory);
    // console.log(a);
    this.store.select(BookTypeState.getSelectedCategory).subscribe(bookTypeId => {
      // load book bases on category.
      if(bookTypeId!==0){
        this.bookService.getBookByType(bookTypeId).subscribe((data: IBook[])=>{
          console.log(data);
          this.books$ = data;
        })  
      }
      else{
        this.bookService.getAll().subscribe((data: IBook[])=>{
          console.log(data);
          this.books$ = data;
        })  
      }
  
    });
  }

  addBookToCart(book:Book){
    
    this.store.dispatch(new AddBookToCart(book));
    
  }


}
