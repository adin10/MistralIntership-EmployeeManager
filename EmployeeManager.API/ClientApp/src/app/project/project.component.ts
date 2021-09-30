import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Project } from '../shared/project.model';
import { projectInsertRequest } from '../shared/requests/projectInsertRequest.model';
import { ProjectService } from '../_services/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor(public service:ProjectService,public fb:FormBuilder) { }
  ProjectList:Project[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  p:number=1;
  projectName:string = "";
  startDateRange:Date=null;
  finishDateRange:Date=null;


  ngOnInit() {
    this.getAllProjects(this.projectName,this.startDateRange,this.finishDateRange);
  
  }
  getAllProjects(projectName: string,startDateRange:Date,finishDateRange:Date){
      this.service.getProject(projectName,this.startDateRange,this.finishDateRange).subscribe(data=>{
        this.ProjectList=data;
      })
  }
  removeAllProjects(){
    this.ProjectList = [];
  }
  
  deleteProject(item){
    this.service.deleteProject(item).subscribe(data=>{
      //this.ProjectList = this.ProjectList.filter(x => x.projectID != item);
      this.getAllProjects(this.projectName,this.startDateRange,this.finishDateRange);
    })
  }
  Search(){
    this.getAllProjects(this.projectName,this.startDateRange,this.finishDateRange);
 }

}
