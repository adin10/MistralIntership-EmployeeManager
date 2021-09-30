import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TeamUpsertRequest } from '../shared/requests/teamUpsertRequest.model';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-update-team',
  templateUrl: './update-team.component.html',
  styleUrls: ['./update-team.component.css']
})
export class UpdateTeamComponent implements OnInit {

  constructor(public service:TeamService,public fb:FormBuilder,public route:ActivatedRoute) { }
  forma:FormGroup;
  alert:boolean=false;

  ngOnInit() {
    this.forma=this.fb.group({
      TeamName:["",[Validators.required,Validators.minLength(5)]],
      startDate:[""],
      finishDate:[""]
    })
    this.service.getTeamById(this.route.snapshot.params.id).subscribe((result)=>{
      this.forma=new FormGroup({
        TeamName:new FormControl(result['teamName']),
      })
     })
  }
  onSubmit(){
    let podaci = new TeamUpsertRequest(this.forma.get('TeamName').value);
    this.service.teamUpdate(this.route.snapshot.params.id,podaci).subscribe((result)=>{
      console.warn(result);
    })
    this.forma.reset();
    this.alert=true;
  }
  CloseClick(){
    this.alert=false;
    }

}
