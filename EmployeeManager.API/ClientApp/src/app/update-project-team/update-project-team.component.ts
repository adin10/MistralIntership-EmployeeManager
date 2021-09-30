import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../shared/project.model';
import { ProjectTeam } from '../shared/projectTeam.model';
import { ProjectTeamUpsertRequest } from '../shared/requests/projectTeamUpsertRequest.model';
import { Team } from '../shared/team.model';
import { ProjectService } from '../_services/project.service';
import { ProjectTeamService } from '../_services/projectTeam.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-update-project-team',
  templateUrl: './update-project-team.component.html',
  styleUrls: ['./update-project-team.component.css']
})
export class UpdateProjectTeamComponent implements OnInit {

  constructor(public fb:FormBuilder,public route:ActivatedRoute, public service:ProjectTeamService,public teamService:TeamService,public projectService:ProjectService) { }
  projectList:Project[]=[];
  forma:FormGroup;
  teamList:Team[]=[];
  projectTeamList:ProjectTeam[]=[];
  ngOnInit() {
    this.forma=this.fb.group({
      projectID:["",[Validators.required]],
      teamID:["",[Validators.required]]
    })
    this.getProjects();
    this.getTeams();
    this.getProjectTeam();


    this.service.getProjectTeamById(this.route.snapshot.params.id).subscribe((result)=>{
      this.forma=new FormGroup({
        projectID:new FormControl(result['projectID']),// ovdje moraju biti nazivi propertija kao u modelu
        teamID:new FormControl((result['teamID']))
      })
     })
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
    this.service.projectTeamUpdate(this.route.snapshot.params.id,podaci).subscribe((result)=>{
      console.warn(result);
    })
    this.forma.reset();
  }


}
