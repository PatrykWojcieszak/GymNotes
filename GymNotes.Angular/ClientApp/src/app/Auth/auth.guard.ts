import { AuthenticationService } from 'src/app/Services/Authentication/Authentication.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
    providedIn: 'root'
  })
  export class AuthGuard implements CanActivate {


    constructor(private router: Router, private authentication: AuthenticationService) {
    }
    canActivate(
      next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): boolean {
      if (this.authentication.UserToken != null)
        return true;
      else {
        // this.router.navigate(['/user/login']);
        this.router.navigate(['/user/login']);
        return false;
      }
    }
  }
