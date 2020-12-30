import { Component, OnInit } from '@angular/core';
import {Select, Store} from '@ngxs/store'
import {AddBookToCart} from '../../store'
import {CartState} from '../../store'

@Component({
  selector: 'app-customer-header',
  templateUrl: './customer-header.component.html',
  styleUrls: ['./customer-header.component.scss']
})
export class CustomerHeaderComponent implements OnInit {
  amount: number = 0 ;
  constructor(private store: Store) { }

  ngOnInit(): void {
    this.store.select(CartState.getAmoutItemInCart).subscribe(amount => {
      this.amount = amount
  
    });
  }


}
