import { Component, OnInit } from '@angular/core';
import {BookService} from './book-service';
import {Book} from './book';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss'],
  providers: [BookService] 
})
export class BookListComponent implements OnInit {

  
  constructor(public bookservice: BookService) { }
  books: Book[] = [];
  ngOnInit(): void {
    
   this.getBookdata();
  }

  getBookdata(){
    this.bookservice.getAll().subscribe((data: Book[])=>{
      console.log(data);
      this.books = data;
    })  
  }

  deleteBook(book:Book){
    console.log(book);
    var a = this.bookservice.delete({...book,isDeleted:true}).subscribe((data:Book)=>{
      console.log(data);
      this.getBookdata();
    });
    

  }


}
