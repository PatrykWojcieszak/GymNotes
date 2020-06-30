import { MatDialogModule } from '@angular/material/dialog';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AddOpinionComponent } from './AddOpinion/AddOpinion.component';
import { UserListComponent } from './UserList/UserList.component';
import { UserProfileComponent } from './UserProfile/UserProfile.component';
import { UserProfileEditAchievementsComponent } from './UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { UserProfileEditingComponent } from './UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';

import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/Shared/shared.module';

@NgModule({
  declarations: [
    UserProfileEditingComponent,
    UserProfileEditAchievementsComponent,
    UserProfileComponent,
    UserListComponent,
    AddOpinionComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    UserRoutingModule,
    SharedModule,
    MatDialogModule,
  ],
  entryComponents: [
    UserProfileEditingComponent,
    UserProfileEditAchievementsComponent,
    AddOpinionComponent,
  ]
})
export class UserModule { }
