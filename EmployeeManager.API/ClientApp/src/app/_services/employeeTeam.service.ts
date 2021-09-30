import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeeTeam } from "../shared/employeeTeam.model";
import { EmployeeTeamUpsertRequest } from "../shared/requests/employeeeTeamUpsertRequest.model";

@Injectable({providedIn:'root'})
export class EmployeeTeamService{
    constructor(private http:HttpClient){}

    getEmployeeTeams(employeeID:number){
        let httpParams = new HttpParams().set("EmployeeID", employeeID.toString()); 
        return this.http.get<EmployeeTeam[]>('https://localhost:5001/api/EmployeeTeam',{
            params: httpParams
        })
    }

    getEmployeeTeamById(id){
        return this.http.get<EmployeeTeam>('https://localhost:5001/api/EmployeeTeam/'+id);
    }
    UpdateEmployeeTeam(id:number,employeeTeam:EmployeeTeamUpsertRequest){
        return this.http.put('https://localhost:5001/api/EmployeeTeam/'+id,employeeTeam);
    }

    addEmployeeTeam(employeeTeam:EmployeeTeamUpsertRequest){
        return this.http.post('https://localhost:5001/api/EmployeeTeam',employeeTeam);
    }
    deleteEmployeeTeam(id:number):Observable<EmployeeTeam>{
        if(confirm("Do you want to remove employeeTeam from list")){
        return this.http.delete<EmployeeTeam>('https://localhost:5001/api/EmployeeTeam/'+id);
        }

    }
}