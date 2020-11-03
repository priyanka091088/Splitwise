import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewfriendlistComponent } from './viewfriendlist.component';

describe('ViewfriendlistComponent', () => {
  let component: ViewfriendlistComponent;
  let fixture: ComponentFixture<ViewfriendlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewfriendlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewfriendlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
