import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSettlementComponent } from './update-settlement.component';

describe('UpdateSettlementComponent', () => {
  let component: UpdateSettlementComponent;
  let fixture: ComponentFixture<UpdateSettlementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateSettlementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateSettlementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
