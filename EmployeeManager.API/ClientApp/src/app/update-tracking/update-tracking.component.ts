import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeTeam } from '../shared/employeeTeam.model';
import {  ProjectTeam} from '../shared/projectTeam.model';
import { TrackingUpdateRequest } from '../shared/requests/trackingUpdateRequest.model';
import { EmployeeTeamService } from '../_services/employeeTeam.service';
import { LoginService } from '../_services/login.service';
import { TrackingService } from '../_services/tracking.service';

@Component({
  selector: 'app-update-tracking',
  templateUrl: './update-tracking.component.html',
  styleUrls: ['./update-tracking.component.css']
})
export class UpdateTrackingComponent implements OnInit {

  constructor(public route:ActivatedRoute,public service:TrackingService, public loginService:LoginService,public fb:FormBuilder,public employeeTeamService:EmployeeTeamService) { }
  forma:FormGroup;
  employeeTeamList:EmployeeTeam[]=[];
  projectTeamList:ProjectTeam[]=[];
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
    this.service.getTrackingsById(this.route.snapshot.params.id).subscribe((result)=>{
      this.forma=new FormGroup({
        workHours:new FormControl(result['workHours']),// ovdje moraju biti nazivi propertija kao u modelu
        date:new FormControl(new Date(result['date']).toISOString().split("T")[0]),
        description:new FormControl(new Date(result['description'])),
        
      })
     })
  }

  getEmployeeTeam(){
    this.employeeTeamService.getEmployeeTeams(this.employeeID).subscribe(data=>{
      this.employeeTeamList=data;
    })

  }

  onSubmit(){
    let podaci=new TrackingUpdateRequest(this.forma.get('employeeTeamID').value,this.forma.get('projectTeamID').value,
    this.forma.get('description').value,this.forma.get('date').value,this.forma.get('workHours').value);
    this.service.updateTracking(this.route.snapshot.params.id,podaci).subscribe(data=>{})
    this.forma.reset();

  }
  updateProjects(){

  }
}
