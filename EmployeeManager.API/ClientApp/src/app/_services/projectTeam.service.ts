import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProjectTeam } from "../shared/projectTeam.model";
import { ProjectTeamUpsertRequest } from "../shared/requests/projectTeamUpsertRequest.model";

@Injectable({providedIn:'root'})
export class ProjectTeamService{
    constructor(private http:HttpClient){}
    
    getProjectTeams(teamID:number){
        let httpParams=new HttpParams().set("TeamID",teamID.toString());
        return this.http.get<ProjectTeam[]>('https://localhost:5001/api/ProjectTeam',{
            params:httpParams
        });
    }
  

    addProjectTeam(projectTeam:ProjectTeamUpsertRequest){
        return this.http.post('https://localhost:5001/api/ProjectTeam',projectTeam);
    }

    getProjectTeamById(id){
        return this.http.get<ProjectTeam>('https://localhost:5001/api/ProjectTeam/'+id);
    }

    projectTeamUpdate(id,project: ProjectTeamUpsertRequest){
        return this.http.put('https://localhost:5001/api/ProjectTeam/' + id,project);
    }
    deleteProjectTeam(id:number):Observable<ProjectTeam>{
        if(confirm("Do you want to delete a project-team from list")){
            return this.http.delete<ProjectTeam>('https://localhost:5001/api/ProjectTeam/'+id);
        }
    }
}