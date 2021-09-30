import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEmployeeTeamComponent } from './update-employee-team.component';

describe('UpdateEmployeeTeamComponent', () => {
  let component: UpdateEmployeeTeamComponent;
  let fixture: ComponentFixture<UpdateEmployeeTeamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateEmployeeTeamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateEmployeeTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
