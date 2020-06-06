import { Login } from './../../../Models/Login';
import { UserLoginInfo } from '../../../Models/UserLoginInfo';
import { Router } from '@angular/router';
import { AuthenticationService } from './../../../Services/Authentication/Authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from 'angularx-social-login';
import { SocialUser } from 'angularx-social-login';
@Component({
	selector: 'app-Login',
	templateUrl: './Login.component.html',
	styleUrls: [ './Login.component.css' ]
})
export class LoginComponent implements OnInit {
	loginForm: FormGroup;
	submitted = false;
	loginError = false;
	loginErrorMessage = '';
	showPass: boolean = false;

	constructor(private formBuilder: FormBuilder, 
		private authenticationService: AuthenticationService, 
		private router: Router) {}

	ngOnInit() {
		this.loginForm = this.formBuilder.group({
			email: [ '', [ Validators.email, Validators.required ] ],
			password: [ '', Validators.required ],
			rememberme: [ true ]
		});

		if(this.authenticationService.UserToken != null)
		{
      this.router.navigateByUrl('/main/userList');
		}
	}

	get form() {
		return this.loginForm.controls;
	}

	onSubmit() {
		this.submitted = true;

		if (this.loginForm.invalid) {
			return;
		}

		var loginModel: Login = {
			Email: this.loginForm.value.email,
			Password: this.loginForm.value.password,
			isPersistent: this.loginForm.value.rememberme
		};

		this.authenticationService.isPersistent = loginModel.isPersistent;

		this.authenticationService.login(loginModel).subscribe(
			(res: UserLoginInfo) => {
				if (loginModel.isPersistent) {
					console.warn(res);
					localStorage.setItem('token', res.token),
					localStorage.setItem('FirstName', res.firstName),
					localStorage.setItem('LastName', res.lastName),
					localStorage.setItem('Alias', res.alias),
        	localStorage.setItem('id', res.id);
				} else {
					sessionStorage.setItem('token', res.token),
					sessionStorage.setItem('id', res.id);
				};
				this.router.navigateByUrl('/main/userList');
			},
			(err) => {
				this.loginError = true;
				this.loginErrorMessage = err.error.message;
			}
		);
	}

	// facebookLogin()
	// {
	// 	this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then(x => console.log(x));
	// }

	// googleLogin()
	// {
	// 	this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then(x => console.log(x));
	// }

	// twitterLogin()
	// {
	// 	this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then(x => console.log(x));
	// }

	showPassword()
	{
		this.showPass = !this.showPass;
	}
}
