import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RightSideNavComponent } from './right-side-nav.component';

describe('RightSideNavComponent', () => {
  let component: RightSideNavComponent;
  let fixture: ComponentFixture<RightSideNavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RightSideNavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RightSideNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
