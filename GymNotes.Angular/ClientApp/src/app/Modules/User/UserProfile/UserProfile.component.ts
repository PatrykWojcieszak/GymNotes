import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { AchievementsStorageService } from './../../../Core/Services/Storage/Achievements-Storage.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { formatDate } from '@angular/common';
import { ActivatedRoute, Params } from '@angular/router';

import { ConfirmationDialogService } from './../../../Core/Services/Utility/ConfirmationDialog.service';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { User } from '../../../Shared/Models/User';
import { AuthenticationService } from '../../../Auth/Authentication.service';
import { UserProfileEditingComponent } from '../UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';
import { AchievementDiscipline } from 'src/app/Shared/Models/Achievements/AchievementDiscipline';

@Component({
  selector: 'app-UserProfile',
  templateUrl: './UserProfile.component.html',
  styleUrls: ['./UserProfile.component.scss']
})
export class UserProfileComponent implements OnInit {

  UserInfo: User = {
    id: '',
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
    alias: '',
    fullName: '',
    description: '',
    discipline: '',
    yearsOfExperience: 0,
    trainingSince: null,
  };

  selectedUserId: string;

  constructor(
    private matDialog: MatDialog,
    public authentication: AuthenticationService,
    private confirmationDialogService: ConfirmationDialogService,
    private route: ActivatedRoute,
    private userService: UserService,
    public achievementsStorage: AchievementsStorageService,
    public utility: UtilityService) { }


  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.selectedUserId = params.id;
      this.getUser(params.id);
      this.getAchievements(params.id);
    });
  }

  getUser(userId: string){
    const parameters = [ userId ];

    this.userService.GetUser(parameters)
      .subscribe((res: User) => {
        this.UserInfo = res;
        this.UserInfo.birthday = formatDate(res.birthday, 'yyyy-MM-dd', 'en-US');
        this.UserInfo.trainingSince = new Date(res.trainingSince);
      });
  }

  getAchievements(userId: string){
    this.achievementsStorage.loadAchievements(userId);
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
