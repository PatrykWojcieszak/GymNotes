import { Component, OnInit, Input } from "@angular/core";

import { ConfirmationDialogService } from "./../../../Core/Services/Utility/ConfirmationDialog.service";
import { MatDialog } from "@angular/material/dialog";
import { AchievementsStorageService } from "./../../../Core/Services/Storage/Achievements-Storage.service";
import { UserProfileEditAchievementsComponent } from "src/app/Modules/User/UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component";

@Component({
  selector: "app-AchievementsList",
  templateUrl: "./AchievementsList.component.html",
  styleUrls: ["./AchievementsList.component.scss"],
})
export class AchievementsListComponent implements OnInit {
  @Input() userId: string;
  @Input() editMode: boolean;
  parameters: string[] = [];

  constructor(
    private confirmationDialog: ConfirmationDialogService,
    private matDialog: MatDialog,
    public achievementsStorage: AchievementsStorageService
  ) {}

  ngOnInit() {
    this.parameters[0] = this.userId;
  }

  OpenAchievementsEditor(id) {
    const dialogRef = this.matDialog.open(
      UserProfileEditAchievementsComponent,
      {
        maxHeight: "100%",
        data: {
          Data: id,
        },
      }
    );
  }

  DeleteAchievement(itemId, index) {
    this.confirmationDialog
      .confirm(
        "Please confirm..",
        "Do you really want to delete these achievements " + "?"
      )
      .then((confirmed) => {
        const parameters: string[] = [this.parameters, itemId];
        this.achievementsStorage.removeAchievement(parameters, index);
      })
      .catch(() => console.log());
  }
}
