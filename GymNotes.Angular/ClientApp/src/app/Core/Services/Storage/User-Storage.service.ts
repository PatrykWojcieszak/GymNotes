import { BehaviorSubject } from "rxjs";
import { Injectable } from "@angular/core";
import { formatDate } from "@angular/common";
import { List } from "immutable";

import { UserService } from "src/app/Core/Services/Http/User/User.service";
import { AuthenticationService } from "src/app/Auth/Authentication.service";
import { UserOpinionService } from "../Http/User/UserOpinion.service";

import { User } from "src/app/Shared/Models/User";
import { UserOpinion } from "src/app/Shared/Models/UserOpinion";

@Injectable({
  providedIn: "root",
})
export class UserStorageService {
  constructor(
    private userService: UserService,
    private authentication: AuthenticationService,
    private userOpinionService: UserOpinionService
  ) {}

  private _user = new BehaviorSubject<User>(new User());
  public readonly User = this._user.asObservable();

  private _opinionsList = new BehaviorSubject<List<UserOpinion>>(List([]));
  public readonly OpinionsList = this._opinionsList.asObservable();

  get UserData() {
    return this._user.value;
  }

  set UserData(value) {
    this._user.next(value);
  }

  loadUserData() {
    const parameters = [this.authentication.UserId];

    this.userService.GetUser(parameters).subscribe((res: User) => {
      const user = res;
      user.birthday = formatDate(res.birthday, "yyyy-MM-dd", "en-US");
      user.trainingSince = new Date(res.trainingSince);

      this._user.next(user);
    });

    this.userOpinionService
      .GetUserOpinion(parameters)
      .subscribe((res: List<UserOpinion>) => {
        this._opinionsList.next(res);
      });
  }
}
