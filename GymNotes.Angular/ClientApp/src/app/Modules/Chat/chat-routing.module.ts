import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChatListComponent } from './ChatList/ChatList.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: ChatListComponent,
    canActivate: [AuthGuard]
  },

  {
    path: 'chat/:id',
    component: ChatListComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChatRoutingModule { }
