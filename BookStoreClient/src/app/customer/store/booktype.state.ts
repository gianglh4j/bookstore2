import {State, Action, StateContext, Selector} from '@ngxs/store';
import {tap} from 'rxjs/operators';

import {
   SelectBookType
} from './actions';


import { Injectable } from '@angular/core';


export interface BookTypeStateModel {
    SelectedbookTypeId: number
}

@State<BookTypeStateModel>({
    name: 'booktype',
    defaults: {
        SelectedbookTypeId: 0
    }
})

@Injectable()
export class BookTypeState {


    @Selector()
    static getSelectedCategory(state: BookTypeStateModel): number {
        return state.SelectedbookTypeId;
    }

    @Action(SelectBookType)
    selectBookType({getState, setState}: StateContext<BookTypeStateModel>,{booktypeId}:SelectBookType) {
            const state = getState();
            setState({
                ...state,
                SelectedbookTypeId: booktypeId,
            });
        
    }

}
