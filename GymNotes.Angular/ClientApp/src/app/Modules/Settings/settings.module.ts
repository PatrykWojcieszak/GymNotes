import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NotificationsComponent } from './Notifications/Notifications.component';
import { SettingsComponent } from './Settings/Settings.component';
import { SecurityComponent } from './Security/Security.component';
import { GeneralSettingsComponent } from './GeneralSettings/GeneralSettings.component';

import { SharedModule } from 'src/app/Shared/shared.module';
import { SettingsRoutingModule } from './settings-routing.module';


@NgModule({
  declarations: [
    GeneralSettingsComponent,
    SecurityComponent,
    SettingsComponent,
    NotificationsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    SettingsRoutingModule,
    SharedModule,
  ],
})
export class SettingsModule { }
