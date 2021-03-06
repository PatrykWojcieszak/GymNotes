import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { Login } from '../../../Shared/Models/Login';
import { UserLoginInfo } from '../../../Shared/Models/UserLoginInfo';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../Auth/Authentication.service';
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
    private router: Router,
    private utilityService: UtilityService) {}

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
			(res: any) => {
				if (loginModel.isPersistent) {
          this.utilityService.putToLocalStorage('currentUser', res);
				} else {
          this.utilityService.putToSessionStorage('currentUser', res);
				};
				this.router.navigateByUrl('/userList');
			},
			(err) => {
        console.warn(err);
        console.warn(err.error.Message);
				this.loginError = true;
				this.loginErrorMessage = err.error.Message;
			}
		);
	}

	showPassword()
	{
		this.showPass = !this.showPass;
	}
}
