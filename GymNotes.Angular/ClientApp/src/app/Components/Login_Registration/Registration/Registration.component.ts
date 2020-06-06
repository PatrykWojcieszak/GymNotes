import { ConfirmationEmailSendedComponent } from '../EmailConfirmation/ConfirmationEmailSended/ConfirmationEmailSended.component';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../../Services/User/User.service';
import { MustMatch } from 'src/app/Validators/MustMatch';
import { MatDialogModule, MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
@Component({
	selector: 'app-Registration',
	templateUrl: './Registration.component.html',
	styleUrls: [ './Registration.component.css' ]
})
export class RegistrationComponent implements OnInit {
	registerForm: FormGroup;
	submitted = false;
	registrationErrorMessage = '';
	registrationError = false;

	constructor(
		private formBuilder: FormBuilder,
		private UserService: UserService,
		private matDialog: MatDialog,
		private routerLink: Router
	) {}

	ngOnInit() {
		this.registerForm = this.formBuilder.group(
			{
				firstName: [ '', Validators.required ],
				lastName: [ '', Validators.required ],
				termsChk: [ false, Validators.required ],
				email: [ '', [ Validators.required, Validators.email ] ],
				password: [ '', [ Validators.required, Validators.minLength(6) ] ],
				confirmPassword: [ '', Validators.required ]
			},
			{
				validator: MustMatch('password', 'confirmPassword')
			}
		);
	}

	comparePasswords(formBuilder: FormGroup) {
		let confirmPswrdCtrl = formBuilder.get('confirmPassword');

		if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
			if (formBuilder.get('password').value != confirmPswrdCtrl.value)
				confirmPswrdCtrl.setErrors({ passwordMismatch: true });
			else confirmPswrdCtrl.setErrors({ passwordMismatch: null });
		}
	}

	get form() {
		return this.registerForm.controls;
	}

	onSubmit() {
		this.submitted = true;

		if (this.registerForm.invalid || this.registerForm.value.termsChk == false) {
			return;
		}

		var registerModel = {
			Email: this.registerForm.value.email,
			Password: this.registerForm.value.password,
			FirstName: this.registerForm.value.firstname,
			LastName: this.registerForm.value.lastname
		};

		this.UserService.Register(registerModel).subscribe(
			(res: any) => {
				const dialogConfig = new MatDialogConfig();
				this.matDialog.open(ConfirmationEmailSendedComponent, dialogConfig);
				this.matDialog._afterAllClosed.subscribe((x) => {
					this.registerForm.reset();
					this.routerLink.navigateByUrl('/user/login');
				});
			},
			(err) => {
				this.registrationError = true;
				this.registrationErrorMessage = err.error.message;
			}
		);
	}
}
