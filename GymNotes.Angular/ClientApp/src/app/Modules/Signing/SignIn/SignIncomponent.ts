import { Login } from '../../../Models/Login';
import { UserLoginInfo } from '../../../Models/UserLoginInfo';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../Services/Authentication/Authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
	selector: 'app-SignIn',
	templateUrl: './SignIn.component.html',
	styleUrls: [ './SignIn.component.scss' ]
})
export class SignInComponent implements OnInit {
	loginForm: FormGroup;
	submitted = false;
	loginError = false;
	loginErrorMessage = '';
	showPass = false;

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
      this.router.navigateByUrl('/userList');
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
				this.router.navigateByUrl('/userList');
			},
			(err) => {
				this.loginError = true;
				this.loginErrorMessage = err.error.message;
			}
		);
	}

	showPassword()
	{
		this.showPass = !this.showPass;
	}
}
