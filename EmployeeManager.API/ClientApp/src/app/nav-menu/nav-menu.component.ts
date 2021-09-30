import { Component } from '@angular/core';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  isLogged:boolean = false;
  constructor(public authService : LoginService) { }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
    logout(){
      this.authService.LogOut();
      this.authService.isAuthenticated = false;
    }
  }

