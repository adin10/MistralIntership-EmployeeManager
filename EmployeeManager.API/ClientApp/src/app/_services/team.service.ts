import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { tap } from "rxjs/operators";

import { TeamUpsertRequest } from "../shared/requests/teamUpsertRequest.model";
import { Team } from "../shared/team.model";
@Injectable({providedIn:'root'})
export class TeamService{
    constructor(private http:HttpClient){}

    private refreshListuAutomatski = new Subject<void>();

    get refreshanuListu() {
        return this.refreshListuAutomatski;
    }
    getTeams(teamName: string){
        let httpParams = new HttpParams().set("TeamName", teamName); // pretraga po nazivu tima
        // "TeamName" mora imati isti naziv kao u apiju
       return this.http.get<Team[]>('https://localhost:5001/api/Team', {
           params: httpParams
       })
    }
    addTeam(team:TeamUpsertRequest){
        return this.http.post('https://localhost:5001/api/Team',team).pipe(
            tap(() => {
                this.refreshListuAutomatski.next();
            })
        );;
    }
    deleteTeam(id:number):Observable<Team>{
        if(confirm("Do you want to delete a team")){
            return this.http.delete<Team>('https://localhost:5001/api/Team/'+id).pipe(
                tap(() => {
                    this.refreshListuAutomatski.next();
                })
            );;
        }
    }
    getTeamById(id){
        return this.http.get<Team>('https://localhost:5001/api/Team/'+id);
    }
    teamUpdate(id,team: TeamUpsertRequest){
        return this.http.put('https://localhost:5001/api/Team/' + id,team);
    }
}