import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Project } from '../shared/project.model';
import { ProjectTeam } from '../shared/projectTeam.model';
import { ProjectTeamUpsertRequest } from '../shared/requests/projectTeamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { ProjectService } from '../_services/project.service';
import { ProjectTeamService } from '../_services/projectTeam.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-project-team',
  templateUrl: './project-team.component.html',
  styleUrls: ['./project-team.component.css']
})
export class ProjectTeamComponent implements OnInit {

  constructor(public fb:FormBuilder, public service:ProjectTeamService,public teamService:TeamService,public projectService:ProjectService) { }
  projectList:Project[]=[];
  forma:FormGroup;
  teamList:Team[]=[];
  projectTeamList:ProjectTeam[]=[];
  ngOnInit() {
    this.forma=this.fb.group({
      projectID:["",[Validators.required]],
      teamID:["",[Validators.required]]
    })
    this.getProjectTeam();
    this.getProjects();
    this.getTeams();
  }
  getProjects(){
    this.projectService.getProject("",null,null).subscribe(data=>{
      this.projectList=data;
    })
  }
  getTeams(){
    this.teamService.getTeams("").subscribe(data=>{
      this.teamList=data;
    })
  }
  getProjectTeam(){
    this.service.getProjectTeams(null).subscribe(data=>{
      this.projectTeamList=data;
    })
  }
  OnSubmit(){
    let podaci=new ProjectTeamUpsertRequest(this.forma.get("projectID").value,this.forma.get("teamID").value);
    this.service.addProjectTeam(podaci).subscribe(data=>{
      this.getProjectTeam();
    })
    this.forma.reset();
  }

  deleteProjectTeam(item){

    this.service.deleteProjectTeam(item).subscribe(data=>{
      this.getProjectTeam();
    })
  }

}
