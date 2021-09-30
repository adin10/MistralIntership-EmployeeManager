import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from '../shared/employee.model';
import { EmployeeInsertRequest } from '../shared/requests/employeeUpsertRequest.model';
import { UserInsertRequest } from '../shared/requests/UserInsertRequest.model';
import { Team } from '../shared/team.model';
import { EmployeeService } from '../_services/employee.service';
import { FileService } from '../_services/file.service';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  constructor(public router:Router,
    public service:EmployeeService,
    private fb:FormBuilder,
    private teamService: TeamService,
    private fileService: FileService) { }
  EmployeeList:Employee[]=[];
  forma:FormGroup;
  alert:boolean=false; 
  FirstName="";
  LastName="";
  teams:Team[];
  fileUrl: string;
  selectedTeams: Team[] = [];
  public response: {
    dbPath: '',
    fileName: '',
    fullPath: ''
  };

  ngOnInit() {
    this.forma=this.fb.group({
      Name:["",[Validators.required]],
      LastName:["",Validators.required],
      DateEmployment:[""],
       Skils:[""],
       Gender:[""],
       Active:[],
       UserPhoto:[],
       Email: ["",Validators.required],
       Username:["",[Validators.required]],
       Password:["",[Validators.required]],
       ConfirmationPassword:["",Validators.required],
       teams: new FormArray([])
      })
      this.teamService.getTeams("").subscribe(data => {this.teams = data;});
    }
  onSubmit(){
    let podaci=new EmployeeInsertRequest(this.forma.get('Name').value,this.forma.get('LastName').value,
    this.forma.get('DateEmployment').value,this.forma.get('Skils').value,this.forma.get('Gender').value,
    this.forma.get('Active').value,
    new UserInsertRequest(this.forma.get('Email').value,this.forma.get('Username').value,
    this.forma.get('Password').value,this.forma.get('ConfirmationPassword').value),this.selectedTeams
    //  this.fileUrl
     );

    this.service.addEmployee(podaci).subscribe(data=>{
      this.getAllEmployees(this.FirstName,this.LastName);
    });
    this.alert=true;
    this.forma.reset();
    this.router.navigate(["/employee"]);
    this.getAllEmployees(this.FirstName,this.LastName);
  }
  CloseClick(){
    this.alert=false;
  }
  getAllEmployees(FirstName:string,LastName:string){
    this.service.getEmployees(FirstName,LastName).subscribe(data=>{
      console.log(data);
      this.EmployeeList=data;
    })
  }
  addTeam(teamId: number){
    console.log(teamId);
    if(this.selectedTeams.some(x => x.teamID == teamId)){
      this.selectedTeams = this.selectedTeams.filter(x => x.teamID != teamId);
    }
    else{
      this.selectedTeams.push(new Team(teamId, ""));
    }
  }
  onFileChanged(event){
    let file = event.target.files[0];
    this.fileService.uploadFile(file).subscribe(x => {
      this.fileUrl = x.url;
      console.log(x);
    })
  }


  public uploadFinished = (event) =>{
   this.response=event;
  }

  public createImgPath = () =>{
    if(this.response!=null)
    return '${environment.apiUrl}${this.response.dbPath}';
  }
}
