import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TeamUpsertRequest } from '../shared/requests/teamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})
export class AddTeamComponent implements OnInit {

  constructor(public router:Router,public service:TeamService,public fb:FormBuilder) { }
  listTeams:Team[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  teamName:string = "";


  ngOnInit() {
    this.forma=this.fb.group({
      TeamName:["",[Validators.required]]
    })
  }
  onSubmit(){
    let podaci=new TeamUpsertRequest(this.forma.get('TeamName').value);
    this.service.addTeam(podaci).subscribe(data=>{this.getAllTeams(this.teamName);});
    this.forma.reset();
    this.alert=true;
    this.router.navigate(["/team"]);
    this.getAllTeams(this.teamName);
  }
  CloseClick(){
    this.alert=false;
  }
  Search(){
     this.getAllTeams(this.teamName); // filtriranje
  }
  getAllTeams(teamName: string){
    this.service.getTeams(teamName).subscribe(data=>{
      this.listTeams=data;
    })
  }

}
