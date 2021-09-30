import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from '../shared/project.model';
import { projectInsertRequest } from '../shared/requests/projectInsertRequest.model';
import { ProjectUpdateRequest } from '../shared/requests/projectUpdateRequest.model';
import { Team } from '../shared/team.model';
import { ProjectService } from '../_services/project.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-update-project',
  templateUrl: './update-project.component.html',
  styleUrls: ['./update-project.component.css']
})
export class UpdateProjectComponent implements OnInit {

  constructor( private teamService: TeamService,public router:Router,public service:ProjectService,private route:ActivatedRoute,public fb:FormBuilder, public datePipe: DatePipe) { }
  forma:FormGroup;
  alert:boolean=false;
  teams:Team[];
  selectedTeams: Team[] = [];
  isChecked: boolean = false;
  project: Project;

  ngOnInit() {
    this.forma=this.fb.group({
      projectName:["",[Validators.required,Validators.minLength(5)]],
      startDate:[""],
      finishDate:[""]
    })
    this.teamService.getTeams("").subscribe(data => {this.teams = data;});
    
    this.service.getProjectById(this.route.snapshot.params.id).subscribe((result)=>{
      this.project = result;
      console.log(this.project);
      console.log(result);
      this.forma=new FormGroup({
        projectName:new FormControl(result['projectName']),// ovdje moraju biti nazivi propertija kao u modelu
        startDate:new FormControl(new Date(result['startDate']).toISOString().split("T")[0]),
        finishDate:new FormControl(new Date(result['finishDate']).toISOString().split("T")[0]),
        
      })
     })
  }
  onSubmit(){
    let podaci = new ProjectUpdateRequest(this.forma.get('projectName').value,this.forma.get('startDate').value,this.forma.get('finishDate').value,this.selectedTeams);
    this.service.projectUpdate(this.route.snapshot.params.id,podaci).subscribe(result=>{
      this.router.navigate(['/project'])
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
      console.log(this.project);
      if(this.project ==undefined || this.project.projectTeams==null || this.project.projectTeams==undefined){
        return false
      }
      return this.project.projectTeams.some(x=>x.teamID==team.teamID);
    }
}
