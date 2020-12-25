import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { HomeComponent } from './home/home.component';
import { BookCollectionComponent } from './book-collection/book-collection.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { BookListComponent } from './book-collection/book-list/book-list.component';


@NgModule({
  declarations: [HomeComponent, BookCollectionComponent, CartComponent, CheckoutComponent, BookListComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule { }
