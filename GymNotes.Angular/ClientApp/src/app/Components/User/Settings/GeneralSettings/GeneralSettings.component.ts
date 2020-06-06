import { AuthenticationService } from 'src/app/Services/Authentication/Authentication.service';
import { UserSettingsService } from './../../../../Services/User/UserSettings.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserLoginInfo } from 'src/app/Models/UserLoginInfo';

@Component({
  selector: 'app-GeneralSettings',
  templateUrl: './GeneralSettings.component.html',
  styleUrls: ['./GeneralSettings.component.css']
})
export class GeneralSettingsComponent implements OnInit {

  showElement: string = '';

  nameForm: FormGroup;
  emailForm: FormGroup;

  nameSubmitted = false;
  emailSubmitted = false;

  userFirstName: string = '';
  userLastName: string = '';
  userAlias: string = '';

  userFullName: UserLoginInfo = {
    token: '',
    id: '',
    firstName: '',
    lastName: '',
    alias: '',
  }

  userEmail: string = '';

  constructor(private userSettings: UserSettingsService, private authentication: AuthenticationService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    let parameters: string[] = [this.authentication.UserId];

    this.userSettings.GetUserFullName(parameters).subscribe((res: UserLoginInfo) => {
      this.userFullName = res;
      
      this.nameForm = this.formBuilder.group({
        userId: [this.authentication.UserId],
        firstname: [ res.firstName, Validators.required ],
        lastname: [ res.lastName, Validators.required ],
        alias: [ res.alias ],
      });
    });
    
    this.userSettings.GetUserEmail(parameters).subscribe((res: any) =>{
      this.userEmail = res.email;
      console.warn(res);
    });

    this.emailForm = this.formBuilder.group({
      userId: [this.authentication.UserId],
			email: [ '', [ Validators.email, Validators.required ] ],
		});
  }

  get getNameForm() {
		return this.nameForm.controls;
  }
  
  get getEmailForm() {
		return this.emailForm.controls;
	}

  elementToggle(name: string){
    this.showElement = name;
  }

  updateName(){
    this.nameSubmitted = true;

    this.userFullName.firstName = this.nameForm.controls.firstname.value;
    this.userFullName.lastName = this.nameForm.controls.lastname.value;
    this.userFullName.alias = this.nameForm.controls.alias.value;

    if (this.nameForm.invalid) {
			return;
    }
    
    this.userSettings.ChangeName(this.nameForm.value).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  updateEmail(){
    this.emailSubmitted = true;

    if (this.emailForm.invalid) {
			return;
    }
    
    this.userEmail = this.emailForm.controls.email.value;

    this.userSettings.ChangeEmail(this.emailForm.value).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }
}
