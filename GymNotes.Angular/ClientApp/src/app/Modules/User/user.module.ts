import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AddOpinionComponent } from './AddOpinion/AddOpinion.component';
import { UserListComponent } from './UserList/UserList.component';
import { UserProfileComponent } from './UserProfile/UserProfile.component';
import { UserProfileEditAchievementsComponent } from './UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { UserProfileEditingComponent } from './UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';

import { UserRoutingModule } from './user-routing.module';

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
    UserRoutingModule,
  ],
  entryComponents: [
    UserProfileEditingComponent,
    UserProfileEditAchievementsComponent,
    AddOpinionComponent,
  ]
})
export class UserModule { }
