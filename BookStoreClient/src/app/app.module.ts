import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {CustomerModule} from './customer/customer.module';
import {AppRoutingModule} from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgxsModule} from '@ngxs/store';

@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    CustomerModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    // NgxsModule.forRoot([BookState]),
    NgxsModule.forRoot([], { developmentMode: true }),
    
    
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
