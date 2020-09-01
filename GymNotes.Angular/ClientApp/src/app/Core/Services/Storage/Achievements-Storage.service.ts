import { BehaviorSubject, Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { List } from "immutable";

import { UserService } from "../Http/User/User.service";
import { AchievementDiscipline } from "src/app/Shared/Models/Achievements/AchievementDiscipline";

@Injectable({
  providedIn: "root",
})
export class AchievementsStorageService {
  private _achievementDiscipline: BehaviorSubject<
    List<AchievementDiscipline>
  > = new BehaviorSubject(List([]));

  public readonly AchievementsList: Observable<
    List<AchievementDiscipline>
  > = this._achievementDiscipline.asObservable();

  constructor(private userService: UserService) {}

  loadAchievements(id) {
    const parameters = [id];

    this.userService
      .GetUserAchievementsList(parameters)
      .subscribe((res: List<AchievementDiscipline>) => {
        this._achievementDiscipline.next(res);
      });
  }

  removeAchievement(parameters, index) {
    this.userService.DeleteUserAchievementsList(parameters).subscribe((res) => {
      console.warn(res);
      const tempAchievements = this._achievementDiscipline.getValue();
      tempAchievements.splice(index, 1);

      this._achievementDiscipline.next(tempAchievements);
    });
  }
}
