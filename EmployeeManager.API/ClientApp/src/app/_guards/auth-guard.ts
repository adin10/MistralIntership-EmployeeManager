import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { LoginService } from "../_services/login.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(public auth: LoginService, public router: Router) { }
  canActivate(): boolean {    
    // auth guard u angularu sprijecava otvaranje ruta koje nisu autorizovane
    if (!this.auth.isAuthenticated) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
} 