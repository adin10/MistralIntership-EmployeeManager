import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../shared/employee.model';
import { EmployeeInsertRequest } from '../shared/requests/employeeUpsertRequest.model';
import { UserInsertRequest } from '../shared/requests/UserInsertRequest.model';
import { EmployeeService } from '../_services/employee.service';

@Component({
  selector: 'app-employe',
  templateUrl: './employe.component.html',
  styleUrls: ['./employe.component.css']
})
export class EmployeComponent implements OnInit {

  constructor(public service:EmployeeService,private fb:FormBuilder) { }
  EmployeeList:Employee[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  FirstName="";
  LastName="";
  p:number=1;

  ngOnInit() {
    this.getAllEmployees(this.FirstName,this.LastName);
  }
  getAllEmployees(FirstName:string,LastName:string){
    this.service.getEmployees(FirstName,LastName).subscribe(data=>{
      console.log(data);
      this.EmployeeList=data;
    })
  }
 
  deleteEmployee(item){
    this.service.deleteEmployee(item).subscribe(data=>{
      this.getAllEmployees(this.FirstName,this.LastName);
    })
  }
  Search(){
    this.getAllEmployees(this.FirstName,this.LastName);
  }
}
