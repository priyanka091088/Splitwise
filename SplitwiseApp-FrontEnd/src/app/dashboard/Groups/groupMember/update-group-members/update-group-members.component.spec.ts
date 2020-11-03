import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateGroupMembersComponent } from './update-group-members.component';

describe('UpdateGroupMembersComponent', () => {
  let component: UpdateGroupMembersComponent;
  let fixture: ComponentFixture<UpdateGroupMembersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateGroupMembersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateGroupMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
