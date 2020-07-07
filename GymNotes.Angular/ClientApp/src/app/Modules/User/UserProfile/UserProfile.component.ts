import { ConfirmationDialogService } from './../../../Core/Services/Utility/ConfirmationDialog.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { UserOpinion } from 'src/app/Shared/Models/UserOpinion';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { UserOpinionService } from 'src/app/Core/Services/Http/User/UserOpinion.service';
import { User } from '../../../Shared/Models/User';
import { AddOpinionComponent } from './../AddOpinion/AddOpinion.component';
import { AuthenticationService } from '../../../Auth/Authentication.service';
import { UserProfileEditAchievementsComponent } from './../UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { UserProfileEditingComponent } from '../UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';
import { ConfirmationDialogComponent } from 'src/app/Shared/Components/ConfirmationDialog/ConfirmationDialog.component';

@Component({
  selector: 'app-UserProfile',
  templateUrl: './UserProfile.component.html',
  styleUrls: ['./UserProfile.component.scss']
})
export class UserProfileComponent implements OnInit {

  AchievementsList: any[];
  CommentsList: UserOpinion[];
  UserInfo: User = {
    facebook: '',
    instagram: '',
    twitter: '',
    youTube: '',
    isCoach: false,
    height: 0,
    birthday:'',
    gender: '',
    firstName: '',
    lastName: '',
    fullName: '',
    description: '',
    discipline: '',
    yearsOfExperience: 0,
    id: '',
  };

  constructor(
    private matDialog: MatDialog,
    private userService: UserService,
    private authentication: AuthenticationService,
    private userOpinionService: UserOpinionService,
    private confirmationDialogService: ConfirmationDialogService) { }

  ngOnInit() {
    let parameters: string[] = [this.authentication.UserId];

    // this.userService.GetUserAchievementsList(parameters).subscribe((res: any[]) => {
    //   console.warn(res);
    //   this.AchievementsList = res;
    // });;
  }

  profileEditing(){
    const dialogRef = this.matDialog.open(UserProfileEditingComponent, {
      height: 'calc(100% - 30px)',
      maxHeight: '100%'
    });
  }

  OpenAcievementsEditor()
  {
    const dialogConfig = new MatDialogConfig();
    this.matDialog.open(UserProfileEditAchievementsComponent, dialogConfig);
  }

  sendCoachingRequest(){
    this.confirmationDialogService
			.confirm(
				'Please confirm..',
				'Do you really want to send coaching request to ' + '?'
			)
			.then((confirmed) => {
				console.log('User confirmed:', confirmed);
			})
			.catch(() =>
				console.log(
					'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
				)
			);
  }
}
