import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {Select, Store} from '@ngxs/store';
import {AddBookToCart,CartState,DecreaseItemCart} from '../store';
import { Book } from '../services';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems : any = [];
  amount : number = 0; 
  total : number = 0;

  constructor(private store: Store) { }

  ngOnInit(): void {

    this.store.select(CartState.getCart).subscribe(cart => {
      this.cartItems = cart.CartItems;
      
    });
  }
decreaseItem(book:Book){
    
    this.store.dispatch(new DecreaseItemCart (book));
   
  }

}
