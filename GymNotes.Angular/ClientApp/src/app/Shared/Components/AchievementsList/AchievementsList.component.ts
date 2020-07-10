import { Component, OnInit, Input } from '@angular/core';

import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { ConfirmationDialogService } from './../../../Core/Services/Utility/ConfirmationDialog.service';
import { MatDialog } from '@angular/material/dialog';
import { AchievementsStorageService } from './../../../Core/Services/Storage/Achievements-Storage.service';
import { UserProfileEditAchievementsComponent } from 'src/app/Modules/User/UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';

@Component({
  selector: 'app-AchievementsList',
  templateUrl: './AchievementsList.component.html',
  styleUrls: ['./AchievementsList.component.scss']
})
export class AchievementsListComponent implements OnInit {

  //AchievementsList: AchievementDiscipline[];

  @Input() userId: string;
  @Input() editMode: boolean;
  parameters: string[] = [];

  constructor(
    private userService: UserService,
    private confirmationDialog: ConfirmationDialogService,
    private matDialog: MatDialog,
    public achievementsStorage: AchievementsStorageService
    ) { }

  ngOnInit() {
    this.parameters[0] = this.userId;
    // this.getAchievements();
  }

  getAchievements(){
    // this.userService.GetUserAchievementsList(this.parameters)
    // .subscribe((res: AchievementDiscipline[]) => {
    //   this.AchievementsList = res;
    // });
  }

  OpenAchievementsEditor(id){
		const dialogRef = this.matDialog.open(UserProfileEditAchievementsComponent, {
			maxHeight: '100%',
			data: {
				Data: id
			}
		});

		// dialogRef.afterClosed().subscribe((x) => {
		// 	this.userService.GetUserAchievementsList(this.parameters).subscribe((res: any[]) => {
    //     this.AchievementsList = res;
		// 	});
		// });
  }

  DeleteAchievement(id){
    this.confirmationDialog
    .confirm(
      'Please confirm..',
      'Do you really want to delete these achievements ' + '?'
    )
    .then((confirmed) => {
      const parameters: string[] = [ this.parameters, id ];
      this.userService.DeleteUserAchievementsList(parameters).subscribe((res) => console.warn(res));
      this.achievementsStorage.AchievementsList = this.achievementsStorage.AchievementsList.filter(x => x.id !== id);
      // this.AchievementsList = this.AchievementsList.filter(x => x.id !== id);
    })
    .catch(() =>
      console.log(
        'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
      )
    );
  }
}
