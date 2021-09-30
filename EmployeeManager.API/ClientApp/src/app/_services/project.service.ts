import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Project } from "../shared/project.model";
import { projectInsertRequest } from "../shared/requests/projectInsertRequest.model";
import { tap } from 'rxjs/operators';
import { convertToObject } from "typescript";
import { ProjectUpdateRequest } from "../shared/requests/projectUpdateRequest.model";

@Injectable({providedIn:'root'})
export class ProjectService{
    constructor(private http:HttpClient){}

    private refreshListuAutomatski = new Subject<void>();

    get refreshanuListu() {
        return this.refreshListuAutomatski;
    }


    // getProject(){
    //     return this.http.get<Project[]>('https://localhost:5001/api/project')
    //     // .pipe(tap(()=>{
    //     //     this.refreshListuAutomatski.next()
    //     // })
    //     // );
    // }
    getProject(projectName: string,startDateRange:Date,finishDateRane:Date){
        let httpParams = new HttpParams()
        .set("ProjectName", projectName)
        .set("FinishDateStartRange", startDateRange != null ? new Date(startDateRange).toDateString() : "")
        .set("FinishDateEndRange", finishDateRane != null ? new Date(finishDateRane).toDateString() : "");
       return this.http.get<Project[]>('https://localhost:5001/api/Project', {
           params: httpParams
       })
    }
    getProjectById(id){
        return this.http.get<Project>('https://localhost:5001/api/project/'+id);
    }
    projectUpdate(id,project: ProjectUpdateRequest){
        return this.http.put('https://localhost:5001/api/project/' + id,project);
    }
    addProject(project:projectInsertRequest){
        return this.http.post('https://localhost:5001/api/Project',project);
    }
    deleteProject(id:number):Observable<Project>{
        if(confirm("Do you want to delete a project from list")){
            return this.http.delete<Project>('https://localhost:5001/api/Project/'+id);
        }
    }
}