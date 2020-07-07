import { UserStorageService } from 'src/app/Core/Services/Storage/User-Storage.service';
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

  constructor(
    private matDialog: MatDialog,
    private authentication: AuthenticationService,
    private confirmationDialogService: ConfirmationDialogService,
    public userStorage: UserStorageService) { }

  ngOnInit() {
  }

  profileEditing(){
    const dialogRef = this.matDialog.open(UserProfileEditingComponent, {
      height: 'calc(100% - 30px)',
      maxHeight: '100%'
    });
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
