import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { UserListComponent } from './UserList/UserList.component';
import { UserProfileComponent } from './UserProfile/UserProfile.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/userList', pathMatch: 'full'
  },
  {
    path: 'userList',
    component: UserListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'userprofile',
    component: UserProfileComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule { }
