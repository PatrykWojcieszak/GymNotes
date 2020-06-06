import { User } from './../../../Models/User';
import { UserOpinionService } from './../../../Services/User/UserOpinion.service';
import { AddOpinionComponent } from './../AddOpinion/AddOpinion.component';
import { AuthenticationService } from './../../../Services/Authentication/Authentication.service';
import { UserService } from './../../../Services/User/User.service';
import { UserProfileEditAchievementsComponent } from './../UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { UserProfileEditingComponent } from '../UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UserOpinion } from 'src/app/Models/UserOpinion';

@Component({
  selector: 'app-UserProfile',
  templateUrl: './UserProfile.component.html',
  styleUrls: ['./UserProfile.component.css']
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
  };

  constructor(
    private matDialog: MatDialog,
    private userService: UserService,
    private authentication: AuthenticationService,
    private userOpinionService: UserOpinionService) { }

  ngOnInit() {
    let parameters: string[] = [this.authentication.UserId];

    this.userOpinionService.GetUserOpinion(parameters).subscribe((res: UserOpinion[]) => {
      this.CommentsList = res;
      console.warn(res);
    });
    // this.userService.GetUserAchievementsList(parameters).subscribe((res: any[]) => {
    //   console.warn(res);
    //   this.AchievementsList = res;
    // });;
  }

  profileEditing(){
    const dialogRef = this.matDialog.open(UserProfileEditingComponent, {
      height: "calc(100% - 30px)",
      maxHeight: "100%"
    });
  }

  OpenAcievementsEditor()
  {
    const dialogConfig = new MatDialogConfig();
    this.matDialog.open(UserProfileEditAchievementsComponent, dialogConfig);
  }

  AddOpinion(){
    const dialogRef = this.matDialog.open(AddOpinionComponent,{
      maxHeight: "100%",
    });

    // let parameters: string[] = [this.authentication.UserId];

    // dialogRef.afterClosed().subscribe((x) => {
    //     this.userService.GetUserAchievementsList(parameters).subscribe((res: any[]) => {
    //     this.AchievementsList = res;
    //   });
    // });
  }

  LikeClick(){
    
  }
}
