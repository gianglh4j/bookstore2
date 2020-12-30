import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooktypeListComponent } from './booktype-list.component';

describe('BooktypeListComponent', () => {
  let component: BooktypeListComponent;
  let fixture: ComponentFixture<BooktypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BooktypeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BooktypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
