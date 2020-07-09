import { Injectable } from '@angular/core';
import { formatDate } from '@angular/common';

import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { UserOpinionService } from '../Http/User/UserOpinion.service';

import { User } from 'src/app/Shared/Models/User';
import { UserOpinion } from 'src/app/Shared/Models/UserOpinion';

@Injectable({
	providedIn: 'root'
})
export class UserStorageService {
	constructor(
    private userService: UserService,
    private authentication: AuthenticationService,
    private userOpinionService: UserOpinionService,) {}

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

    CommentsList: UserOpinion[];

    getUserData() {
      const parameters = [ this.authentication.UserId ];

      this.userService.GetUser(parameters)
      .subscribe((res: User) => {
        this.UserInfo = res;
        this.UserInfo.birthday = formatDate(res.birthday, 'yyyy-MM-dd', 'en-US');
        this.UserInfo.trainingSince = new Date(res.trainingSince);
      });

      this.userOpinionService.GetUserOpinion(parameters)
      .subscribe((res: UserOpinion[]) => {
        this.CommentsList = res;
      });
    }

    public printProp(val: any): string {
      if (!val) {
        return '-';
      }
      return '' + val;
    }
}
