import { Injectable } from '@angular/core';

import { UserService } from '../Http/User/User.service';
import { AchievementDiscipline } from 'src/app/Shared/Models/Achievements/AchievementDiscipline';

@Injectable({
  providedIn: 'root'
})
export class AchievementsStorageService {

  AchievementsList: AchievementDiscipline[];

  constructor(private userService: UserService,) { }

  getAchievements(id){
    const parameters = [id];

    this.userService.GetUserAchievementsList(parameters)
    .subscribe((res: AchievementDiscipline[]) => {
      this.AchievementsList = res;
    });
  }
}
