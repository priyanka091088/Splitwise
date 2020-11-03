import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSettlementComponent } from './view-settlement.component';

describe('ViewSettlementComponent', () => {
  let component: ViewSettlementComponent;
  let fixture: ComponentFixture<ViewSettlementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSettlementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSettlementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
