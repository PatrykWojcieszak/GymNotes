import { UserInfoService } from './../../../../Services/User/UserInfo.service';
import { SelectBoxService } from './../../../../Services/Base/SelectBox.service';
import { UserService } from './../../../../Services/User/User.service';
import { User } from './../../../../Models/User';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserProfileEditAchievementsComponent } from '../UserProfileEditAchievements/UserProfileEditAchievements.component';
import { AuthenticationService } from 'src/app/Services/Authentication/Authentication.service';
import { formatDate  } from '@angular/common';
import * as $ from 'jquery';
@Component({
  selector: 'app-UserProfileEditing',
  templateUrl: './UserProfileEditing.component.html',
  styleUrls: ['./UserProfileEditing.component.css']
})
export class UserProfileEditingComponent implements OnInit {

  showDescriptionEdit: boolean = false;
  showDisciplineEdit: boolean = false;
  showYearsOfExperienceEdit: boolean = false;
  showBirthdayEdit: boolean = false;
  showGenderEdit: boolean = false;
  showIsCoachEdit: boolean = false;
  showHeightEdit: boolean = false;

  years: number[] = [];
  months: string[] = [];
  days: number[] = [];

  showElement: string = '';

  birthdayYear: string = 'Year';
  birthdayMonth: string = 'Month';
  birthdayDay: string = 'Day';

  isSelectBoxInitialized: boolean = false;
  basicInfo: boolean = false;
  currentYear: number;
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
    fullName: '',
    lastName: '',
    description: '',
    discipline: '',
    yearsOfExperience: 0,
  };

  AchievementsList: any[];

  constructor(
    private dialogRef: MatDialogRef<UserProfileEditingComponent>, @Inject(MAT_DIALOG_DATA) Data,
    private matDialog: MatDialog,
    private userService: UserService,
    private userAuthentication: AuthenticationService,
    private selectBox: SelectBoxService,
    private userInfo: UserInfoService) { }

  ngOnInit() {
    this.currentYear = new Date().getFullYear()

    let parameters: string[] = [this.userAuthentication.UserId];
    this.userService.GetUserUpdateInfo(parameters).subscribe((res: User) => {
      this.UserInfo = res;
      this.initBirthday(res.birthday);
      this.UserInfo.birthday = formatDate(res.birthday, 'yyyy-MM-dd', 'en-US');
    });

    this.userService.GetUserAchievementsList(parameters).subscribe((res: any[]) => {
      this.AchievementsList = res;
    });
  }
  
  initBirthday(birthday: string){
    const birthdayDate = new Date(birthday);

    this.birthdayYear = birthdayDate.getFullYear().toString();
    this.birthdayMonth = birthdayDate.toLocaleString('en-US', { month: 'long' });
    this.birthdayDay = birthdayDate.getDate().toString();

    this.initYears();
    this.initMonths();
    this.initDays(birthdayDate.getFullYear(), this.getNumberOfMonth( birthdayDate.toLocaleString('en-US', { month: 'long' })));
  }

  getNumberOfMonth(month: string){
    return  this.months.indexOf(month);
  }

  OpenAcievementsEditor(id)
  {
    const dialogRef = this.matDialog.open(UserProfileEditAchievementsComponent,{
      maxHeight: "100%",
      data: {
        Data: id
      }
    });

    let parameters: string[] = [this.userAuthentication.UserId];

    dialogRef.afterClosed().subscribe((x) => {
        this.userService.GetUserAchievementsList(parameters).subscribe((res: any[]) => {
        this.AchievementsList = res;
      });
    });
  }

  showBasicInfo(){
    this.basicInfo = !this.basicInfo;
  }

  close() {
    this.dialogRef.close();
  }

  updateInstagramURL(e: any){
    const model = {
      userId: this.userAuthentication.UserId,
      uRL: this.UserInfo.instagram,
    }
    console.warn(model);
    this.userInfo.UpdateInstagramUrl(model).subscribe(
			(res: any) => {
        
			},
			(err) => {

			}
		);
  }

  updateFacebookURL(e: any){
    const model = {
      userId: "this.userAuthentication.UserId",
      uRL: this.UserInfo.facebook,
    }

    this.userInfo.UpdateFacebookUrl(model).subscribe(
			(res: any) => {
        
			},
			(err) => {

			}
		);
  }

  updateTwitterURL(e: any){
    const model = {
      userId: this.userAuthentication.UserId,
      uRL: this.UserInfo.twitter,
    }

    this.userInfo.UpdateTwitterUrl(model).subscribe(
			(res: any) => {
        
			},
			(err) => {

			}
		);
  }

  updateYoutubeURL(e: any){
    const model = {
      userId: this.userAuthentication.UserId,
      uRL: this.UserInfo.youTube,
    }

    this.userInfo.UpdateYoutubeUrl(model).subscribe(
			(res: any) => {
        
			},
			(err) => {

			}
		);
  }

  updateIsCoach(){
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.UserInfo.isCoach,
    }

    this.userInfo.UpdateIsCoach(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  isCoachChanged(e: boolean){
    this.UserInfo.isCoach = e;
  }

  updateGender(){
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.UserInfo.gender,
    }

    this.userInfo.UpdateGender(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  genderChanged(e: string){
    this.UserInfo.gender = e;
  }

  updateDescription(){
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.UserInfo.description,
    }

    this.userInfo.UpdateDescription(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  updateDiscipline(){
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.UserInfo.discipline,
    }

    this.userInfo.UpdateDiscipline(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  updateYearsOfExperience(){
    const model = {
      userId: this.userAuthentication.UserId,
      value: this.UserInfo.yearsOfExperience,
    }

    this.userInfo.UpdateYearsOfExperience(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);
  }

  yearsOfExperienceChanged(e: any){
    this.UserInfo.yearsOfExperience = e;
  }

  updateheight(){
    const model = {
      userId: this.userAuthentication.UserId,
      value: this.UserInfo.height,
    }

    this.userInfo.UpdateHeight(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);;
  }

  updateBirthday(){
    const date = new Date(Number(this.birthdayYear), this.getNumberOfMonth(this.birthdayMonth), Number(this.birthdayDay), 1);

    if(date == null)
      return;

    this.UserInfo.birthday = formatDate(date, 'yyyy-MM-dd', 'en-US');

    const model = {
      userId: this.userAuthentication.UserId,
      date: date,
    }

    this.userInfo.UpdateBirthday(model).subscribe(
			(res: any) => {
        this.showElement = '';
			},
			(err) => {

			}
		);;
  }

  DeleteAchievement(id){
    let parameters: string[] = [this.userAuthentication.UserId,id];
    this.userService.DeleteUserAchievementsList(parameters).subscribe(res => console.warn(res));
  }

  ngAfterViewChecked(){
    if(!this.isSelectBoxInitialized && this.showElement != '')
    {
      this.selectBox.RunScript();
      this.isSelectBoxInitialized = true;
    }
  }

  toggle(componentName: string) {
    if(componentName == '')
      this.isSelectBoxInitialized = false;

    this.showElement = componentName;
  }

  initYears(){
    for (let i = 1930; i <= new Date().getFullYear(); i++) {
      this.years.push(i);
    }
  }

  initMonths(){
    for (let i = 0; i < 12; i++) {
      const date = new Date(new Date().getFullYear(), i); 

      const month = date.toLocaleString('en-US', { month: 'long' });

      this.months.push(month);
    }
  }

  initDays(year: number, month: number){
    this.days = [];

    var d = new Date(year, month + 1, 0);
    const numberOfDays = d.getDate();

    for (let i = 1; i <= numberOfDays; i++) {
      this.days.push(i);
    }
  }

  yearChanged(e:any){
    this.birthdayYear = e;

    this.initDays(Number(e), this.getNumberOfMonth(this.birthdayMonth)); 
  }

  monthChanged(e:any){
    this.birthdayMonth = e;

    this.initDays(Number(this.birthdayYear), this.getNumberOfMonth(e));
  }

  dayChanged(e:any){
    this.birthdayDay = e;
  }
}
