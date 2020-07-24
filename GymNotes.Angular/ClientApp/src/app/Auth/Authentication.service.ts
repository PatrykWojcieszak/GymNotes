import { UtilityService } from './../Core/Services/Utility/Utility.service';
import { AuthenticatedUser } from './../Shared/Models/User/AuthenticatedUser';
import { TokenDecoded } from './../Shared/Models/TokenDecoded';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, config } from 'rxjs';
import * as JWT from 'jwt-decode';
import { JwtHelperService } from '@auth0/angular-jwt';

import { UserLoginInfo } from '../Shared/Models/UserLoginInfo';
import { UserService } from '../Core/Services/Http/User/User.service';
import { map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class AuthenticationService {
  public isPersistent: boolean;
  private userSubject: BehaviorSubject<AuthenticatedUser>;
  public user: Observable<AuthenticatedUser>;

	constructor(
    private userService: UserService,
    private router: Router,
    private utilityService: UtilityService
    ) {
      if(JSON.parse(localStorage.getItem('currentUser')) != null)
        this.userSubject = new BehaviorSubject<AuthenticatedUser>(JSON.parse(localStorage.getItem('currentUser')));
      else
        this.userSubject = new BehaviorSubject<AuthenticatedUser>(JSON.parse(sessionStorage.getItem('currentUser')));

      this.user = this.userSubject.asObservable();
	}

  public get userValue(): AuthenticatedUser {
    return this.userSubject.value;
  }

	public get UserId(){
    let userId;

    if (localStorage.getItem('currentUser') != null){
      const user: AuthenticatedUser = JSON.parse(localStorage.getItem('currentUser'));
      userId = user.id;
    }
    else if(sessionStorage.getItem('currentUser') != null){
      const user: AuthenticatedUser = JSON.parse(sessionStorage.getItem('currentUser'));
      userId = user.id;
    }

		return userId;
	}

	public get UserToken(){
    let token;

    if (localStorage.getItem('currentUser') != null){
      const user: AuthenticatedUser = JSON.parse(localStorage.getItem('currentUser'));
      token = user.jwtToken;
    }
    else if(sessionStorage.getItem('currentUser') != null){
      const user: AuthenticatedUser = JSON.parse(sessionStorage.getItem('currentUser'));
      token = user.jwtToken;
    }

    return token;
	}

	public get UserFullName(){
		if (localStorage.getItem('token') != null)
      return localStorage.getItem('FirstName') + " " + localStorage.getItem('LastName');
    else if(sessionStorage.getItem('token') != null){
      return sessionStorage.getItem('FirstName') + " " + sessionStorage.getItem('LastName');
    }
    else {
			return null;
		}
	}

	public get UserFirstname(){
		if (localStorage.getItem('token') != null)
      return localStorage.getItem('FirstName');
    else if(sessionStorage.getItem('token') != null){
      return sessionStorage.getItem('FirstName');
    }
    else {
			return null;
		}
	}

	public get UserAlias(){
		if (localStorage.getItem('token') != null)
      return localStorage.getItem('Alias');
    else if(sessionStorage.getItem('token') != null){
      return sessionStorage.getItem('Alias');
    }
    else {
			return null;
		}
	}

	public get UserLastname(){
		if (localStorage.getItem('token') != null)
      return localStorage.getItem('LastName');
    else if(sessionStorage.getItem('token') != null){
      return sessionStorage.getItem('LastName');
    }
    else {
			return null;
		}
	}

  getTokenExpirationDate(): Date {
    const helper = new JwtHelperService();

    const decodedToken = helper.decodeToken(localStorage.getItem('token'));
    const expirationDate = helper.getTokenExpirationDate(localStorage.getItem('token'));
    const isExpired = helper.isTokenExpired(localStorage.getItem('token'));

    console.warn(decodedToken);
    console.warn(expirationDate);
    console.warn(isExpired);

    return expirationDate;
  }

  login(loginModel) {
    return this.userService.Login(loginModel).pipe(map((user: AuthenticatedUser) => {
      this.userSubject.next(user);
      this.startRefreshTokenTimer();
      return user;
    }));
  }

	logout() {
    this.stopRefreshTokenTimer();
    this.userSubject.next(null);
		localStorage.removeItem('currentUser');
		sessionStorage.removeItem('currentUser');
		this.router.navigate([ '/user/login' ]);
  }

  refreshToken() {
    return this.userService.RefreshToken().pipe(map((user: AuthenticatedUser) => {
      this.userSubject.next(user);
      console.warn(user);
      if(this.isPersistent)
        this.utilityService.putToLocalStorage('currentUser', user);
      else
        this.utilityService.putToSessionStorage('currentUser', user);
      console.warn("refresh token");
      this.startRefreshTokenTimer();
      return user;
    }));
  }

  private refreshTokenTimeout;

  private startRefreshTokenTimer() {
    const jwtToken = JSON.parse(atob(this.userValue.jwtToken.split('.')[1]));

    const expires = new Date(jwtToken.exp * 1000);
    const timeout = expires.getTime() - Date.now() - (60 * 1000);
    console.warn('timeout start: ' + timeout)
    this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
  }

  private stopRefreshTokenTimer() {
    clearTimeout(this.refreshTokenTimeout);
  }
}
