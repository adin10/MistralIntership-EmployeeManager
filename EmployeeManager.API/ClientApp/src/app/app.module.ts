import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{FormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import{ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { EmployeComponent } from './employe/employe.component';
import { ProjectComponent } from './project/project.component';
import { TeamComponent } from './team/team.component';
import{NgxPaginationModule} from 'ngx-pagination';
import { TokenInterceptor } from './auth/token.interceptor';
import { UpdateProjectComponent } from './update-project/update-project.component';
import { UpdateTeamComponent } from './update-team/update-team.component';
import { UpdateEmployeeComponent } from './update-employee/update-employee.component';
import { EmployeeTeamComponent } from './employee-team/employee-team.component';
import { ProjectTeamComponent } from './project-team/project-team.component';
import { DatePipe } from '@angular/common';
import { UpdateEmployeeTeamComponent } from './update-employee-team/update-employee-team.component';
import { UpdateProjectTeamComponent } from './update-project-team/update-project-team.component';
import { AuthGuard } from './_guards/auth-guard';
import { ProfileComponent } from './profile/profile.component';
import { AddProjectComponent } from './add-project/add-project.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { AddTeamComponent } from './add-team/add-team.component';
import { TrackingComponent } from './tracking/tracking.component';
import { AddTrackingComponent } from './add-tracking/add-tracking.component';
import { UpdateTrackingComponent } from './update-tracking/update-tracking.component';
import { UploadComponent } from './upload/upload.component';
import { PokusajComponent } from './pokusaj/pokusaj.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    LogoutComponent,
    EmployeComponent,
    ProjectComponent,
    TeamComponent,
    UpdateProjectComponent,
    UpdateTeamComponent,
    UpdateEmployeeComponent,
    EmployeeTeamComponent,
    ProjectTeamComponent,
    UpdateEmployeeTeamComponent,
    UpdateProjectTeamComponent,
    ProfileComponent,
    AddProjectComponent,
    AddEmployeeComponent,
    AddTeamComponent,
    TrackingComponent,
    AddTrackingComponent,
    UpdateTrackingComponent,
    UploadComponent,
    PokusajComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgxPaginationModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      {path:"login",component:LoginComponent},
      {path:"employee",component:EmployeComponent, canActivate: [AuthGuard]},
      {path:"project",component:ProjectComponent, canActivate: [AuthGuard]},
      {path:"projectTeam",component:ProjectTeamComponent, canActivate: [AuthGuard]},
      {path:"team",component:TeamComponent, canActivate: [AuthGuard]},
      {path:"employeeTeam",component:EmployeeTeamComponent, canActivate: [AuthGuard]},
      {path:"projectTeam",component:ProjectTeamComponent, canActivate: [AuthGuard]},
      {path:"updateProject/:id",component:UpdateProjectComponent, canActivate: [AuthGuard]},
      {path:"updateTeam/:id",component:UpdateTeamComponent, canActivate: [AuthGuard]},
      {path:"updateEmployee/:id",component:UpdateEmployeeComponent, canActivate: [AuthGuard]},
      {path:"updateEmployeeTeam/:id",component:UpdateEmployeeTeamComponent, canActivate: [AuthGuard]},
      {path:"updateProjectTeam/:id",component:UpdateProjectTeamComponent},
      {path:"updateTracking/:id",component:UpdateTrackingComponent},
      {path:"profile",component:ProfileComponent},
      {path:"addProject",component:AddProjectComponent},
      {path:"addEmployee",component:AddEmployeeComponent},
      {path:"addTeam",component:AddTeamComponent},
      {path:"tracking",component:TrackingComponent},
      {path:"addTracking",component:AddTrackingComponent}
    ])
  ],
  providers: [
    AuthGuard,
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
