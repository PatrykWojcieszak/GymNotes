import { PasswordResetedComponent } from './../PasswordReseted/PasswordReseted.component';
import { UserService } from './../../../../Services/User/User.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MustMatch } from 'src/app/Validators/MustMatch';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ResetPasswordEmailSentComponent } from '../ResetPasswordEmailSent/ResetPasswordEmailSent.component';

@Component({
  selector: 'app-ResetPassword',
  templateUrl: './ResetPassword.component.html',
  styleUrls: ['./ResetPassword.component.css']
})
export class ResetPasswordComponent implements OnInit {

  passwordForm: FormGroup;
  submitted = false;
	params: any;

  constructor(private formBuilder: FormBuilder,
		private userService: UserService,
		private Activatedroute: ActivatedRoute,
		private routerLink: Router,
		private matDialog: MatDialog,) { }

  ngOnInit() {
    this.passwordForm = this.formBuilder.group(
			{
				password: [ '', [ Validators.required, Validators.minLength(6) ] ],
				confirmPassword: [ '', Validators.required ]
			},
			{
				validator: MustMatch('password', 'confirmPassword')
			}
		);

		this.Activatedroute.queryParamMap.subscribe((params) => {
			this.params = params;
		});
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
		return this.passwordForm.controls;
  }
  
  onSubmit()
  {
		this.submitted = true;
		
		if (this.passwordForm.invalid) {
			return;
		}

		var resetPasswordModel = {
			Password: this.passwordForm.value.password,
			Email: this.params.get('email'),
			Token: this.params.get('token'),
		};

    this.userService.ResetPassword(resetPasswordModel).subscribe(
			(res: any) => {
				const dialogConfig = new MatDialogConfig();
				this.matDialog.open(PasswordResetedComponent, dialogConfig);
				this.matDialog._afterAllClosed.subscribe((x) => {
					this.routerLink.navigateByUrl('/user/login');
				});
			},
			(err) => {

			}
		);
  }
}
