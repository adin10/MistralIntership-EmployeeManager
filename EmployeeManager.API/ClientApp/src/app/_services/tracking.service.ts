import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { tap } from "rxjs/operators";
import { TrackingInsertRequest } from "../shared/requests/TrackingInsertRequest.model";
import { Tracking } from "../shared/tracking.model";

@Injectable({"providedIn":'root'})
export class TrackingService{
constructor(public http:HttpClient){}

private refreshListuAutomatski = new Subject<void>();

get refreshanuListu() {
    return this.refreshListuAutomatski;
}

    addTracking(request:TrackingInsertRequest ){
       return this.http.post('https://localhost:5001/api/Tracking',request);
    }
    getTrackings(){
        return this.http.get<Tracking[]>('https://localhost:5001/api/Tracking');
    }
    getTrackingsById(id:number){
        return this.http.get<Tracking>('https://localhost:5001/api/Tracking/'+id);
    }
    deleteTracking(id:number):Observable<Tracking>{
        if(confirm("Do you want to delete a tracking")){
            return this.http.delete<Tracking>('https://localhost:5001/api/Tracking/'+id);
        }
    }
    updateTracking(id:number,request:TrackingInsertRequest){
        return this.http.put('https://localhost:5001/api/Tracking/' + id,request);
    }
}