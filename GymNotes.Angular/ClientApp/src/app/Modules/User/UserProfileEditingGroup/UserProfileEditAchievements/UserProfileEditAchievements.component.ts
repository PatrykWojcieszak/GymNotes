import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, Validators, FormArray, FormBuilder, FormControl } from '@angular/forms';

import { AuthenticationService } from '../../../../Auth/Authentication.service';
import { Achievement } from '../../../../Shared/Models/Achievement';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';

@Component({
  selector: 'app-UserProfileEditAchievements',
  templateUrl: './UserProfileEditAchievements.component.html',
  styleUrls: ['./UserProfileEditAchievements.component.scss']
})
export class UserProfileEditAchievementsComponent implements OnInit {

  myForm: FormGroup;
  AchievementModel: any = {};
  FieldRequired: boolean = false;
  AchievementDyscyplineId: number;

  constructor(
    private dialogRef: MatDialogRef<UserProfileEditAchievementsComponent>, @Inject(MAT_DIALOG_DATA) public Data: any,
    private fb: FormBuilder,
    private userService: UserService,
    private authentication: AuthenticationService) { }

  ngOnInit() {

    if(this.Data.Data != null)
    {
      let parameters: string[] = [this.authentication.UserId, this.Data.Data];

      this.userService.GetUserAchievements(parameters).subscribe(res => {
        this.AchievementModel = res;
        this.loadForm(res);
        this.myForm.patchValue(res);
      });
    }

    this.myForm = new FormGroup({
            name: new FormControl('', Validators.required),
            id: new FormControl(0),
            achievements: new FormArray(
              [
                //this.initWeek(),
              ]
            )
          });
  }

  loadForm(object) {
    for (let achievement = 0; achievement < object.achievements.length; achievement++) {
			this.addAchievement();
		}
  }

	getAchievement(form) {
		return form.controls.achievements.controls;
  }

  removeAchievement(i) {
    const control = <FormArray>this.myForm.get('achievements');
    const form = <FormGroup>control.at(i);
    const achievementId = form.controls.id.value;

    control.removeAt(i);

    if(achievementId != 0)
    {
    let parameters: string[] = [this.authentication.UserId, achievementId];

    this.userService.DeleteUserAchievements(parameters).subscribe(res => console.warn(res));
    }
  }

  addAchievement() {
		const control = <FormArray>this.myForm.get('achievements');
		control.push(this.initAchievement());
	}

  initAchievement() {
		return new FormGroup({
      id: new FormControl(0),
			place: new FormControl('', Validators.required),
			date: new FormControl('', Validators.required),
			name: new FormControl('', Validators.required),
		});
  }

  close() {
    this.dialogRef.close();
  }

  onSubmit(){

    this.RequiredFields();

    if (this.myForm.invalid) {
			return;
    }

    let parameters: string[] = [this.authentication.UserId];

    this.userService.AddOrUpdateUserAchievements(this.myForm.value, parameters).subscribe((res: any) => {
        this.dialogRef.close();
			},
			(err) => {

			}
		);
  }

  RequiredFields()
  {
    const control = <FormArray>this.myForm.get('achievements');

    if(control.status == "INVALID"){
      this.FieldRequired = true;
    }
    else{
      this.FieldRequired = false;
    }
  }

  AchievementChanged(e: any) {
    this.RequiredFields();
  }

  WhatPlaceSelected(i){
    const control = <FormArray>this.myForm.get('achievements');
    const form = <FormGroup>control.at(i);
    return form.controls.place.value;
  }
}
