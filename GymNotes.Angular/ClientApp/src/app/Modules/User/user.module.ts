import { UserCardComponent } from './UserList/UserCard/UserCard.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { CommentSectionComponent } from './UserProfile/CommentSection/CommentSection.component';
import { AddOpinionComponent } from './AddOpinion/AddOpinion.component';
import { UserListComponent } from './UserList/UserList.component';
import { UserProfileComponent } from './UserProfile/UserProfile.component';
import { UserProfileEditAchievementsComponent } from './UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { UserProfileEditingComponent } from './UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';

import { UserRoutingModule } from './user-routing.module';
import { AngularMaterialModule } from './../../angular-material.module';
import { SharedModule } from 'src/app/Shared/shared.module';

@NgModule({
  declarations: [
    UserProfileEditingComponent,
    UserProfileEditAchievementsComponent,
    UserProfileComponent,
    UserListComponent,
    AddOpinionComponent,
    CommentSectionComponent,
    UserCardComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    UserRoutingModule,
    SharedModule,
    AngularMaterialModule,
  ],
  entryComponents: [
    UserProfileEditingComponent,
    UserProfileEditAchievementsComponent,
    AddOpinionComponent,
  ]
})
export class UserModule { }
