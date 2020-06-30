import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { ResetPasswordEmailSentComponent } from './../ResetPasswordEmailSent/ResetPasswordEmailSent.component';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';

@Component({
  selector: 'app-PasswordResetEmail',
  templateUrl: './PasswordResetEmail.component.html',
  styleUrls: ['./PasswordResetEmail.component.scss']
})
export class PasswordResetEmailComponent implements OnInit {

  emailForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private matDialog: MatDialog,) { }

  ngOnInit() {
    this.emailForm = this.formBuilder.group({
			email: [ '', [ Validators.email, Validators.required ] ]
		});
  }

  get form() {
		return this.emailForm.controls;
  }

  submit(){
    this.submitted = true;

    if (this.emailForm.invalid) {
			return;
		}

		var forgotPasswordModel = {
			Email: this.emailForm.value.email,
		};

    this.userService.ForgotPassword(forgotPasswordModel).subscribe(
			(res: any) => {
				const dialogConfig = new MatDialogConfig();
				this.matDialog.open(ResetPasswordEmailSentComponent, dialogConfig);
			},
			(err) => {

			}
		);
  }

  backToSignIn()
  {
    this.router.navigateByUrl('/user/login');
  }
}
