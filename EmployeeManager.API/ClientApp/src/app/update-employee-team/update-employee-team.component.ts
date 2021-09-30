import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../shared/employee.model';
import { EmployeeTeam } from '../shared/employeeTeam.model';
import { EmployeeTeamUpsertRequest } from '../shared/requests/employeeeTeamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { EmployeeService } from '../_services/employee.service';
import { EmployeeTeamService } from '../_services/employeeTeam.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-update-employee-team',
  templateUrl: './update-employee-team.component.html',
  styleUrls: ['./update-employee-team.component.css']
})
export class UpdateEmployeeTeamComponent implements OnInit {

  constructor(public route:ActivatedRoute, public fb:FormBuilder, public service:EmployeeTeamService,public employeeService:EmployeeService,public teamService:TeamService ) { }
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
    this.service.getEmployeeTeamById(this.route.snapshot.params.id).subscribe((result)=>{
      this.forma=new FormGroup({
        employeeID:new FormControl(result["employeeID"]),
        teamID:new FormControl(result["teamID"])
      })
    })
  }
  getEmployees(){
    this.employeeService.getEmployees("","").subscribe(data=>{
      this.employeeList=data;
    })
}
getTeams(){
  this.teamService.getTeams(null).subscribe(data=>{
    this.teamList=data;
  })
}

getEmployeeTeam(){
  this.service.getEmployeeTeams(null).subscribe(data=>{
    this.employeeTeamList=data;
  })
}

  OnSubmit(){
      let podaci=new EmployeeTeamUpsertRequest(this.forma.get("employeeID").value,this.forma.get("teamID").value);
      this.service.UpdateEmployeeTeam(this.route.snapshot.params.id,podaci).subscribe(result=>{
        console.warn(result);
      })
      this.forma.reset();
  }

}
