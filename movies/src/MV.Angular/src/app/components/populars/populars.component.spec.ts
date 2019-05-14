import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularsComponent } from './populars.component';

describe('PopularsComponent', () => {
  let component: PopularsComponent;
  let fixture: ComponentFixture<PopularsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopularsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopularsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
