import { Component, OnInit } from '@angular/core';
import {BookTypeService} from './book-type-service';
import {BookType} from '../../services';
import {Select, Store} from '@ngxs/store';
import {SelectBookType} from '../../store'


@Component({
  selector: 'app-booktype-list',
  templateUrl: './booktype-list.component.html',
  styleUrls: ['./booktype-list.component.scss']
})
export class BooktypeListComponent implements OnInit {

  booktypes: BookType[] = [];
  selectedBookTypeId :number = 0;
  constructor(public  bookTypeService: BookTypeService, private store: Store ){

  }

  ngOnInit(): void {
    this.bookTypeService.getAll().subscribe((data: BookType[])=>{
      console.log(data);
      this.booktypes = data;
    })  
  }

  getbookType(id: number){
    this.selectedBookTypeId = id;
    this.store.dispatch(new SelectBookType(this.selectedBookTypeId));
    console.log(this.selectedBookTypeId);
  }


}
