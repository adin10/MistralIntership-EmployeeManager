import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeTeam } from '../shared/employeeTeam.model';
import { ProjectTeam } from '../shared/projectTeam.model';
import { TrackingInsertRequest } from '../shared/requests/TrackingInsertRequest.model';
import { Tracking } from '../shared/tracking.model';
import { EmployeeTeamService } from '../_services/employeeTeam.service';
import { LoginService } from '../_services/login.service';
import { ProjectTeamService } from '../_services/projectTeam.service';
import { TrackingService } from '../_services/tracking.service';

@Component({
  selector: 'app-add-tracking',
  templateUrl: './add-tracking.component.html',
  styleUrls: ['./add-tracking.component.css']
})
export class AddTrackingComponent implements OnInit {

  constructor(public trackingService:TrackingService,
    public employeeTeamService:EmployeeTeamService,
    public projectTeamService:ProjectTeamService,
    public loginService: LoginService,
    public fb:FormBuilder,
    public router:Router) { }

  forma:FormGroup;
  employeeTeamList:EmployeeTeam[]=[];
  projectTeamList:ProjectTeam[]=[];
  trackingList:Tracking[]=[];
  employeeID:number = null;
  
 
  ngOnInit() {
    this.employeeID = this.loginService.EmployeeID;
    this.forma=this.fb.group({
      employeeTeamID: ["", [Validators.required]],
      projectTeamID: ["", [Validators.required]],
      date:["",[Validators.required]],
      workHours:["",[Validators.required]],
      description:["",Validators.required]
    })
    this.getEmployeeTeam();
  }
  getEmployeeTeam(){
    this.employeeTeamService.getEmployeeTeams(this.employeeID).subscribe(data=>{
      this.employeeTeamList=data;
    })
  }
  getTrackings(){
    this.trackingService.getTrackings().subscribe(data=>{
       this.trackingList=data;
    })
  }
onSubmit(){
  let podaci=new TrackingInsertRequest(this.forma.get('employeeTeamID').value,this.forma.get('projectTeamID').value,
  this.forma.get('description').value,this.forma.get('date').value,this.forma.get('workHours').value);
  this.trackingService.addTracking(podaci).subscribe(data=>{
    this.getTrackings();
  });
  this.router.navigate(["/tracking"]);
  this.getTrackings();
}

updateProjects(){
  let etId:number = this.forma.get('employeeTeamID').value;
  let teamID:number=this.employeeTeamList.find(q=>q.employeeTeamID==etId).teamID;
  this.projectTeamService.getProjectTeams(teamID).subscribe(data => {
    this.projectTeamList = data;
  });
}
}
