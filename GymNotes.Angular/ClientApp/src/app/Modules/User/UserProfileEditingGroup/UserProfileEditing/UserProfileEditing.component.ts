import { Component, OnInit, Inject } from "@angular/core";
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from "@angular/material/dialog";
import { formatDate } from "@angular/common";

import { UserStorageService } from "src/app/Core/Services/Storage/User-Storage.service";
import { UserProfileEditAchievementsComponent } from "../UserProfileEditAchievements/UserProfileEditAchievements.component";
import { AuthenticationService } from "src/app/Auth/Authentication.service";
import { UserService } from "src/app/Core/Services/Http/User/User.service";
import { UserInfoService } from "src/app/Core/Services/Http/User/UserInfo.service";

@Component({
  selector: "app-UserProfileEditing",
  templateUrl: "./UserProfileEditing.component.html",
  styleUrls: ["./UserProfileEditing.component.scss"],
})
export class UserProfileEditingComponent implements OnInit {
  showDescriptionEdit = false;
  showDisciplineEdit = false;
  showYearsOfExperienceEdit = false;
  showBirthdayEdit = false;
  showGenderEdit = false;
  showIsCoachEdit = false;
  showHeightEdit = false;

  years: number[] = [];
  months: string[] = [];
  days: number[] = [];

  showElement = "";

  birthdayYear = "Year";
  birthdayMonth = "Month";
  birthdayDay = "Day";

  isSelectBoxInitialized = false;
  basicInfo = false;
  currentYear: number;

  AchievementsList: any[];

  genderDropdownList = {
    1: "Male",
    2: "Female",
    3: "Other",
  };

  coachDropdownList = {
    1: "YES",
    2: "NO",
  };

  constructor(
    private dialogRef: MatDialogRef<UserProfileEditingComponent>,
    @Inject(MAT_DIALOG_DATA) Data,
    private matDialog: MatDialog,
    private userService: UserService,
    public userAuthentication: AuthenticationService,
    private userInfo: UserInfoService,
    public userStorage: UserStorageService
  ) {}

  ngOnInit() {
    this.currentYear = new Date().getFullYear();
    this.initBirthday(this.userStorage.UserData.birthday);

    const parameters: string[] = [this.userAuthentication.UserId];

    this.userService
      .GetUserAchievementsList(parameters)
      .subscribe((res: any[]) => {
        this.AchievementsList = res;
      });
  }

  initBirthday(birthday: string) {
    const birthdayDate = new Date(birthday);

    this.birthdayYear = birthdayDate.getFullYear().toString();
    this.birthdayMonth = birthdayDate.toLocaleString("en-US", {
      month: "long",
    });
    this.birthdayDay = birthdayDate.getDate().toString();

    this.initYears();
    this.initMonths();
    this.initDays(
      birthdayDate.getFullYear(),
      this.getNumberOfMonth(
        birthdayDate.toLocaleString("en-US", {
          month: "long",
        })
      )
    );
  }

  getNumberOfMonth(month: string) {
    return this.months.indexOf(month);
  }

  OpenAcievementsEditor(id) {
    const dialogRef = this.matDialog.open(
      UserProfileEditAchievementsComponent,
      {
        maxHeight: "100%",
        data: {
          Data: id,
        },
      }
    );

    const parameters: string[] = [this.userAuthentication.UserId];

    dialogRef.afterClosed().subscribe((x) => {
      this.userService
        .GetUserAchievementsList(parameters)
        .subscribe((res: any[]) => {
          this.AchievementsList = res;
          console.warn(res);
        });
    });
  }

  showBasicInfo() {
    this.basicInfo = !this.basicInfo;
  }

  close() {
    this.dialogRef.close();
  }

  updateInstagramURL(e: any) {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.instagram,
    };

    this.userInfo.UpdateInstagramUrl(model).subscribe(
      (res: any) => {},
      (err) => {}
    );
  }

  updateFacebookURL(e: any) {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.facebook,
    };

    console.log(model);
    this.userInfo.UpdateFacebookUrl(model).subscribe(
      (res: any) => {},
      (err) => {}
    );
  }

  updateTwitterURL(e: any) {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.twitter,
    };

    this.userInfo.UpdateTwitterUrl(model).subscribe(
      (res: any) => {},
      (err) => {}
    );
  }

  updateYoutubeURL(e: any) {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.youTube,
    };

    this.userInfo.UpdateYoutubeUrl(model).subscribe(
      (res: any) => {},
      (err) => {}
    );
  }

  updateIsCoach() {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.isCoach,
    };

    this.userInfo.UpdateIsCoach(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  isCoachChanged(isCoach) {
    if (isCoach === 1) this.userStorage.UserData.isCoach = true;
    else this.userStorage.UserData.isCoach = false;
  }

  updateGender() {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.gender,
    };

    this.userInfo.UpdateGender(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  genderChanged(e) {
    if (e === 1) this.userStorage.UserData.gender = "Male";
    else if (e === 2) this.userStorage.UserData.gender = "Female";
    else this.userStorage.UserData.gender = "Other";
  }

  updateDescription() {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.description,
    };

    this.userInfo.UpdateDescription(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  updateDiscipline() {
    const model = {
      userId: this.userAuthentication.UserId,
      content: this.userStorage.UserData.discipline,
    };

    this.userInfo.UpdateDiscipline(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  updateTrainingSince() {
    const model = {
      userId: this.userAuthentication.UserId,
      date: this.userStorage.UserData.trainingSince,
    };

    this.userInfo.UpdateTrainingSince(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  trainingSinceChanged(e: any) {
    this.userStorage.UserData.trainingSince = new Date(e.toString());
  }

  updateheight() {
    const model = {
      userId: this.userAuthentication.UserId,
      value: this.userStorage.UserData.height,
    };

    this.userInfo.UpdateHeight(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  updateBirthday() {
    const date = new Date(
      Number(this.birthdayYear),
      this.getNumberOfMonth(this.birthdayMonth),
      Number(this.birthdayDay),
      1
    );

    if (date == null) return;

    this.userStorage.UserData.birthday = formatDate(
      date,
      "yyyy-MM-dd",
      "en-US"
    );

    const model = {
      userId: this.userAuthentication.UserId,
      date: date,
    };

    this.userInfo.UpdateBirthday(model).subscribe(
      (res: any) => {
        this.showElement = "";
      },
      (err) => {}
    );
  }

  ngAfterViewChecked() {
    if (!this.isSelectBoxInitialized && this.showElement !== "") {
      this.isSelectBoxInitialized = true;
    }
  }

  toggle(componentName: string) {
    if (componentName === "") this.isSelectBoxInitialized = false;

    this.showElement = componentName;
  }

  initYears() {
    for (let i = 1930; i <= new Date().getFullYear(); i++) {
      this.years.push(i);
    }
  }

  initMonths() {
    for (let i = 0; i < 12; i++) {
      const date = new Date(new Date().getFullYear(), i);

      const month = date.toLocaleString("en-US", {
        month: "long",
      });

      this.months.push(month);
    }
  }

  initDays(year: number, month: number) {
    this.days = [];

    const d = new Date(year, month + 1, 0);
    const numberOfDays = d.getDate();

    for (let i = 1; i <= numberOfDays; i++) {
      this.days.push(i);
    }
  }

  yearChanged(e: any) {
    this.birthdayYear = e;

    this.initDays(Number(e), this.getNumberOfMonth(this.birthdayMonth));
  }

  monthChanged(e: any) {
    this.birthdayMonth = e;

    this.initDays(Number(this.birthdayYear), this.getNumberOfMonth(e));
  }

  dayChanged(e: any) {
    this.birthdayDay = e;
  }
}
