import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewListGroupComponent } from './view-list-group.component';

describe('ViewListGroupComponent', () => {
  let component: ViewListGroupComponent;
  let fixture: ComponentFixture<ViewListGroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewListGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewListGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
