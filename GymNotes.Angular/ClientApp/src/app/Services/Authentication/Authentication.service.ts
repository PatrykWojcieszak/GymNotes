import { UserLoginInfo } from '../../Models/UserLoginInfo';
import { Router } from '@angular/router';
import { UserService } from './../User/User.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, config } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AuthenticationService {
  public isPersistent: boolean;

	constructor(private UserService: UserService, private router: Router) {
	}

	public get UserId(){
		if (localStorage.getItem('id') != null)
      return localStorage.getItem('id');
    else if(sessionStorage.getItem('id') != null){
      return sessionStorage.getItem('id');
    }
    else {
			return null;
		}
	}

	public get UserToken(){
		if (localStorage.getItem('token') != null)
      return localStorage.getItem('token');
    else if(sessionStorage.getItem('token') != null){
      return sessionStorage.getItem('token');
    }
    else {
			return null;
		}
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

	login(loginModel) {
				return this.UserService.Login(loginModel);
	}

	logout() {
		localStorage.removeItem('token');
		sessionStorage.removeItem('token');
		this.router.navigate([ '/user/login' ]);
	}
}
