
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JsonFormatter } from 'tslint/lib/formatters';
import { LoginInsertRequest } from '../shared/requests/loginInsertRequests.model';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public loginService:LoginService, private fb:FormBuilder,private route:Router) { }
  forma:FormGroup;
  data:any;
  ngOnInit() {
    if(this.loginService.isAuthenticated){
      this.route.navigate(["/"]);
    }
    this.initForm();
  }

  initForm(){
    this.forma=this.fb.group({
      username:["",[Validators.required]],
      password:["",Validators.required]
    })
  }
  dodaj() {
    if (this.forma.valid) {
      let login = new LoginInsertRequest(this.forma.get('username').value, this.forma.get('password').value);
      this.loginService.Login(login).subscribe(data => {
        localStorage.setItem('token', data.token);
        this.loginService.EmployeeID = data.employee.employeeID;
        this.loginService.isAuthenticated=true;
        this.route.navigate(['/']);
      });

      
      this.forma.reset();
    }
  }
}
