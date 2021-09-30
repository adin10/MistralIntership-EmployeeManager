import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../shared/employee.model';
import { EmployeeTeam } from '../shared/employeeTeam.model';
import { EmployeeTeamUpsertRequest } from '../shared/requests/employeeeTeamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { EmployeeService } from '../_services/employee.service';
import { EmployeeTeamService } from '../_services/employeeTeam.service';
import { ProjectService } from '../_services/project.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-employee-team',
  templateUrl: './employee-team.component.html',
  styleUrls: ['./employee-team.component.css']
})
export class EmployeeTeamComponent implements OnInit {

  constructor(public service:EmployeeTeamService,public teamService:TeamService,public employeeService:EmployeeService,public fb:FormBuilder) { }
  employeeTeamList:EmployeeTeam[]=[];
  teamList:Team[]=[];
  forma:FormGroup;
  employeeList:Employee[]=[];
  ngOnInit() {
    this.getEmployees();
    this.getTeams();
    this.getEmployeeTeam();

    this.forma=this.fb.group({
      employeeID:["",[Validators.required]],
      teamID:["",[Validators.required]]
    })
  }

  getEmployees(){
      this.employeeService.getEmployees("","").subscribe(data=>{
        this.employeeList=data;
      })
  }
  getTeams(){
    this.teamService.getTeams("").subscribe(data=>{
      this.teamList=data;
    })
  }
  getEmployeeTeam(){
    this.service.getEmployeeTeams(null).subscribe(data=>{
      this.employeeTeamList=data;
    })
  }
  
  OnSubmit(){
    // if(this.forma.invalid){
    //   return;
    // }
    let podaci=new EmployeeTeamUpsertRequest(+this.forma.get('employeeID').value,+this.forma.get('teamID').value)
    this.service.addEmployeeTeam(podaci).subscribe(data=>{
      console.log(data);
    })
    this.forma.reset();
  }

  DeleteEmployeTeam(item){
    this.service.deleteEmployeeTeam(item).subscribe(data=>{
      this.getEmployeeTeam();
    })
  }
}
