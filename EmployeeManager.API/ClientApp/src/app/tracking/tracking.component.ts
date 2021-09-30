import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmployeeTeam } from '../shared/employeeTeam.model';
import { ProjectTeam } from '../shared/project.model';
import { TrackingInsertRequest } from '../shared/requests/TrackingInsertRequest.model';
import { Tracking } from '../shared/tracking.model';
import { EmployeeTeamService } from '../_services/employeeTeam.service';
import { ProjectTeamService } from '../_services/projectTeam.service';
import { TrackingService } from '../_services/tracking.service';

@Component({
  selector: 'app-tracking',
  templateUrl: './tracking.component.html',
  styleUrls: ['./tracking.component.css']
})
export class TrackingComponent implements OnInit {
constructor(public trackingService:TrackingService){}
  
trackingList:Tracking[]=[];
p:number=1;
  ngOnInit() {
    this.getTrackings();
  }
  getTrackings(){
    this.trackingService.getTrackings().subscribe(data=>{
       this.trackingList=data;
    })
  }
  deleteTracking(item){
    this.trackingService.deleteTracking(item).subscribe(data=>{
      this.getTrackings();
    })
  }

 

  

}
