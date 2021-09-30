import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PokusajComponent } from './pokusaj.component';

describe('PokusajComponent', () => {
  let component: PokusajComponent;
  let fixture: ComponentFixture<PokusajComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PokusajComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PokusajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
