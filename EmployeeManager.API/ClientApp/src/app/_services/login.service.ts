import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { Employee } from "../shared/employee.model";
import { AuthenticationResult } from "../shared/requests/authenticationResult.model";
import { LoginInsertRequest } from "../shared/requests/loginInsertRequests.model";

@Injectable({providedIn:'root'})
export class LoginService{

    // private userSubject: BehaviorSubject<Employee>;
    // public user: Observable<Employee>;

    public isAuthenticated = false;
    public EmployeeID = null;
  
    constructor(private http:HttpClient,private router:Router){
        this.isAuthenticated = localStorage.getItem('token') != null && localStorage.getItem('token') != undefined && localStorage.getItem('token') != "";

        // this.userSubject = new BehaviorSubject<Employee>(JSON.parse(localStorage.getItem('user')));
        // this.user = this.userSubject.asObservable();
    };
    Login(add:LoginInsertRequest){
        return this.http.post<AuthenticationResult>('https://localhost:5001/api/Authentication/Login',add);
    }
    // isAuthenticated(): boolean {
    //     return localStorage.getItem('token') != null && localStorage.getItem('token') != undefined && localStorage.getItem('token') != "";
    // }
    LogOut(){
        localStorage.removeItem('token');
        this.router.navigate(['/login']);
    }
}