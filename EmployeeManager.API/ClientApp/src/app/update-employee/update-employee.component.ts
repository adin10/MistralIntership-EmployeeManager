import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../shared/employee.model';
import { Project } from '../shared/project.model';
import { EmployeeUpdateRequest } from '../shared/requests/employeeUpsertRequest.model';
import { UserUpdateRequest } from '../shared/requests/UserUpdateRequest.model';
import { Team } from '../shared/team.model';
import { EmployeeService } from '../_services/employee.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {
  constructor(private teamService:TeamService,public service:EmployeeService,private route:ActivatedRoute,public fb:FormBuilder) { }
  forma:FormGroup;
  alert:boolean=false;
  teams:Team[];
  selectedTeams: Team[] = [];
  isChecked: boolean = false;
  project: Project;
  employeee:Employee;

  ngOnInit() {
    this.forma=this.fb.group({
      Name:["",[Validators.required]],
      LastName:["",Validators.required],
      DateEmployment:[""],
       Skils:[""],
      Gender:[""],
       Active:[""],
       Telephone: ["",Validators.required],
       Username:["",[Validators.required]],
       Email:["",[Validators.required]],
       Password:["",[Validators.required]],
       CurrentPassword:["",Validators.required]
    })


    this.teamService.getTeams("").subscribe(data => {this.teams = data;});
    this.service.getEmployeeById(this.route.snapshot.params.id).subscribe((result)=>{
      this.employeee=result;
      this.forma=new FormGroup({
        Name:new FormControl(result['firstName']),
        LastName:new FormControl(result['lastName']),
        DateEmployment:new FormControl(new Date(result['dateEmployment']).toISOString().split("T")[0]),
        Skils:new FormControl(result['skils']),
        Gender:new FormControl(result['gender']),
        Active:new FormControl(result['active']),
        Username:new FormControl(result['user']['username']),
        Email: new FormControl(result['user']['email']),
        Password:new FormControl(),
        CurrentPassword:new FormControl()
        // Email:new FormControl(),
        // // Username:new FormControl(result['user.Username']),
      })
     })
  }
  onSubmit(){
    let podaci=new EmployeeUpdateRequest(this.forma.get('Name').value,this.forma.get('LastName').value,
    this.forma.get('DateEmployment').value,this.forma.get('Skils').value,this.forma.get('Gender').value,
    this.forma.get('Active').value,new UserUpdateRequest(this.forma.get('Email').value,
    this.forma.get('Password').value,this.forma.get('CurrentPassword').value),this.selectedTeams);
    // ,this.forma.get('user').value);
    this.service.EmployeeUpdate(this.route.snapshot.params.id,podaci).subscribe((result)=>{
      console.warn(result);
    })
    this.forma.reset();
    this.alert=true;
  }
  CloseClick(){
    this.alert=false;
    }
    addTeam(teamId: number){
      console.log(teamId);
      if(this.selectedTeams.some(x => x.teamID == teamId)){
        this.selectedTeams = this.selectedTeams.filter(x => x.teamID != teamId);
      }
      else{
        this.selectedTeams.push(new Team(teamId, ""));
      }
    }

    public contains(team: Team): boolean{
      if(team == null || this.teams ==undefined || this.employeee == null || this.employeee == undefined || this.employeee.employeeTeams==undefined){
        return false
      }
      return this.employeee.employeeTeams.some(x=>x.teamID==team.teamID);
    }
}
