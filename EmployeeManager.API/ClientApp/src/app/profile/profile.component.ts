import { Component, OnInit } from '@angular/core';
import { Employee } from '../shared/employee.model';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  employee:Employee;
  isLogged=false;
  constructor(public auth:LoginService) { }

  ngOnInit() {
    // this.auth.user.subscribe(data=>{
    //   this.employee=data;
    // })
  }

}
