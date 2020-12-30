import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';

import { CustomerRoutingModule } from './customer-routing.module';
import { HomeComponent } from './home/home.component';
import { BookCollectionComponent } from './book-collection/book-collection.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { BookListComponent } from './book-collection/book-list/book-list.component';
import { CustomerHeaderComponent } from './layout/customer-header/customer-header.component';
import { CustomerFooterComponent } from './layout/customer-footer/customer-footer.component';
import { BooktypeListComponent } from './book-collection/booktype-list/booktype-list.component';
import { BookTypeState,CartState} from './store';



@NgModule({
  declarations: [HomeComponent, BookCollectionComponent, CartComponent, CheckoutComponent, BookListComponent, CustomerHeaderComponent, CustomerFooterComponent, BooktypeListComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    NgxsModule.forFeature([BookTypeState,CartState]),
    NgxsReduxDevtoolsPluginModule.forRoot(),
  ]
})
export class CustomerModule { }
