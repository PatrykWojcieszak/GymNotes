import { MustMatch } from 'src/app/Validators/MustMatch';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { UserSettingsService } from 'src/app/Services/User/UserSettings.service';
import { AuthenticationService } from 'src/app/Services/Authentication/Authentication.service';

@Component({
  selector: 'app-Security',
  templateUrl: './Security.component.html',
  styleUrls: ['./Security.component.scss']
})
export class SecurityComponent implements OnInit {

  showElement: string = '';
  passwordSubmitted = false;
  changePasswordError: boolean = false;
  changePasswordErrorMessage: boolean = false;
  passwordForm: FormGroup;

  constructor(
    private userSettings: UserSettingsService,
    private authentication: AuthenticationService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.passwordForm = this.formBuilder.group({
        oldPassword: [ '', [Validators.required, Validators.minLength(6)] ],
        newPassword: [ '', [ Validators.required, Validators.minLength(6) ] ],
        confirmPassword: [ '', Validators.required ],
      },
			{
				validator: MustMatch('newPassword', 'confirmPassword')
			});
  }

  elementToggle(name: string){
    this.showElement = name;
  }

  get getPasswordForm() {
		return this.passwordForm.controls;
	}

  onSubmit() {
		this.passwordSubmitted = true;

		if (this.passwordForm.invalid) {
			return;
		}

		var passwordModel = {
			oldPassword: this.passwordForm.value.oldPassword,
			newPassword: this.passwordForm.value.newPassword,
			userId: this.authentication.UserId,
		};

		this.userSettings.ChangePassword(passwordModel).subscribe(
			(res: any) => {
        this.showElement = '';
        this.passwordForm.reset();
			},
			(err) => {
				this.changePasswordError = true;
				this.changePasswordErrorMessage = err.error;
			}
		);
	}
}
