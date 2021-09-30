import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateProjectTeamComponent } from './update-project-team.component';

describe('UpdateProjectTeamComponent', () => {
  let component: UpdateProjectTeamComponent;
  let fixture: ComponentFixture<UpdateProjectTeamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateProjectTeamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateProjectTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
