import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TeamUpsertRequest } from '../shared/requests/teamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  constructor(public service:TeamService,public fb:FormBuilder) { }
  listTeams:Team[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  teamName:string = "";
  p:number=1;

  ngOnInit() {
   
  this.getAllTeams(this.teamName);
  }

  getAllTeams(teamName: string){
    this.service.getTeams(teamName).subscribe(data=>{
      this.listTeams=data;
    })
  }
 

  deleteTeam(item){
    this.service.deleteTeam(item).subscribe(data=>{
      this.getAllTeams(this.teamName);
    })
  }
  CloseClick(){
    this.alert=false;
  }
  Search(){
     this.getAllTeams(this.teamName); // filtriranje
  }
}
