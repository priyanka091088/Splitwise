import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatefriendComponent } from './updatefriend.component';

describe('UpdatefriendComponent', () => {
  let component: UpdatefriendComponent;
  let fixture: ComponentFixture<UpdatefriendComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatefriendComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatefriendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
