import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Project } from '../shared/project.model';
import { projectInsertRequest } from '../shared/requests/projectInsertRequest.model';
import { Team } from '../shared/team.model';
import { ProjectService } from '../_services/project.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  constructor(public router:Router,public service:ProjectService,public fb:FormBuilder, private teamService: TeamService) { }
  ProjectList:Project[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  projectName:string = "";
  startDateRange:Date=null;
  finishDateRange:Date=null;
  teams:Team[];

  selectedTeams: Team[] = [];
  ngOnInit() {
    this.forma=this.fb.group({
      projectName:["",[Validators.required]],
      startDate:[""],
      finishDate:[""],
      teams: new FormArray([])
    });
    this.teamService.getTeams("").subscribe(data => {this.teams = data;});
  }
  getAllProjects(projectName: string,startDateRange:Date,finishDateRange:Date){
    this.service.getProject(projectName,this.startDateRange,this.finishDateRange).subscribe(data=>{
      this.ProjectList=data;
    })
}
  onSubmit(){
    let podaci=new projectInsertRequest(this.forma.get('projectName').value,this.forma.get('startDate').value,this.forma.get('finishDate').value, this.selectedTeams);
    this.service.addProject(podaci).subscribe(data=>{});
    this.alert=true;
    this.forma.reset();
    this.router.navigate(["/project"]);
    this.getAllProjects(this.projectName,this.startDateRange,this.finishDateRange);
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
}
