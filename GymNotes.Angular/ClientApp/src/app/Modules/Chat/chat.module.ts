import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ChatListComponent } from './ChatList/ChatList.component';
import { ChatMessageBoxComponent } from './ChatMessageBox/ChatMessageBox.component';

import { ChatRoutingModule } from './chat-routing.module';


@NgModule({
  declarations: [
    ChatListComponent,
    ChatMessageBoxComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ChatRoutingModule,
  ],
})
export class ChatModule { }
