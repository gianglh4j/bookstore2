import {State, Action, StateContext, Selector} from '@ngxs/store';
import {ICart} from './models';


import {
   AddBookToCart,DecreaseItemCart
} from './actions';


import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';


export interface CartStateModel {
    Cart: ICart;
}

@State<CartStateModel>({
    name: 'Cart',
    defaults: {
        Cart:{
            CartItems:[],
            Amount:0,
            Total:0
        }
    }
})

@Injectable()
export class CartState {


    @Selector()
    static getAmoutItemInCart(state: CartStateModel): number {
        return state.Cart.Amount;
    }
    @Selector()
    static getCart(state: CartStateModel): ICart {
        return state.Cart;
    }
    @Action(DecreaseItemCart)
    decreaseItemCart({getState, setState}: StateContext<CartStateModel>,{book}:DecreaseItemCart){
        const state = getState();
        const cart = state.Cart;

        let new_CartItems = [...cart.CartItems];

        new_CartItems = new_CartItems.filter(cartItem => cartItem.quantity > 1)
        console.log(new_CartItems);
        new_CartItems = new_CartItems.map((cartItem) =>{
            if(cartItem.book.bookId == book.bookId){

                    return {...cartItem,quantity:cartItem.quantity - 1}          
                        
            }
            return cartItem;
        })
        setState({
            ...state,
            Cart:{
                ...cart,
                CartItems:new_CartItems,
                Amount:cart.Amount - 1,
                Total: cart.Total -  book.bookPrice
            }
        });

        // let new_CartItems= cart.CartItems.map(cartItem =>{
        //     if(cartItem.book.bookId == bookId){
        //         let newCartItem  = {...cartItem, quantity:cartItem.quantity-1}
        //         return newCartItem
        //     }
             
        //     });
    }

    @Action(AddBookToCart)
    addBookToCart({getState, setState}: StateContext<CartStateModel>,{book}:AddBookToCart) {
            const state = getState();
            const cart = state.Cart;
         
            if(cart.Amount === 0){
                let cartitem = {
                    book: book,
                    quantity:1
                }
                setState({
                    ...state,
                    Cart:{
                        ...cart,
                        CartItems:[...cart.CartItems,cartitem],
                        Amount:cart.Amount+1,
                        Total: cart.Total + book.bookPrice
                    }
                });

            }else{
                let check = false;
                cart.CartItems.map((cartitem,key)=>{
                    if(cartitem.book.bookId === book.bookId){
                        check=true;
                        
                        let new_CartItems= cart.CartItems.map(element => element.book.bookId == book.bookId ? {...element, quantity : element.quantity + 1 } : element);

                        // let a = [...cart.CartItems, {...cartitem,quantity:cartitem.quantity+1}];
                        // console.log(a);
                        setState({
                            ...state,
                            Cart:{
                                ...cart,
                                //CartItems:[...cart.CartItems],
                                CartItems:new_CartItems,
                                Amount:cart.Amount+1,
                                Total: cart.Total + book.bookPrice
                            }
                        });
                    }
                })
                if(!check){
                    let cartitem = {
                        book: book,
                        quantity:1
                    }
                    setState({
                        ...state,
                        Cart:{
                            ...cart,
                            CartItems:[...cart.CartItems,cartitem],
                            Amount:cart.Amount+1,
                            Total: cart.Total + book.bookPrice
                        }
                    });
                }
            }

          
        
    }

}


