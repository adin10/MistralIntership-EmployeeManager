import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { tap } from "rxjs/operators";
import { Employee } from "../shared/employee.model";
import { EmployeeInsertRequest, EmployeeUpdateRequest } from "../shared/requests/employeeUpsertRequest.model";

@Injectable({"providedIn":'root'})
export class EmployeeService{
    constructor(private http:HttpClient){}
    private refreshListuAutomatski = new Subject<void>();

    get refreshanuListu() {
        return this.refreshListuAutomatski;
    }
    getEmployees(FirstName:string,LastName:string, userId?:number){
        let params=new HttpParams()
            .set("FirstName",FirstName)
            .set("LastName",LastName)
            .set("UserID", userId != null ? userId.toString() : '');
            
        return this.http.get<Employee[]>('https://localhost:5001/api/Employee',{
            params:params
        });
    }
    
    addEmployee(employee:EmployeeInsertRequest){
        return this.http.post('https://localhost:5001/api/Employee',employee);
    }

    deleteEmployee(id:number):Observable<Employee>{
        if(confirm("Do you want to delete a employee")){
            return this.http.delete<Employee>('https://localhost:5001/api/Employee/'+id).pipe(
                tap(() => {
                    this.refreshListuAutomatski.next();
                })
            );;
        }
    }
    getEmployeeById(id){
        return this.http.get<Employee>('https://localhost:5001/api/Employee/'+id);
    }
    EmployeeUpdate(id,employee: EmployeeUpdateRequest){
        return this.http.put('https://localhost:5001/api/Employee/' + id,employee);
    }
    
}