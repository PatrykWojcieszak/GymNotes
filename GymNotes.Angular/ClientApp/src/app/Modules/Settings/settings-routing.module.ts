import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NotificationsComponent } from './Notifications/Notifications.component';
import { SettingsComponent } from './Settings/Settings.component';
import { SecurityComponent } from './Security/Security.component';
import { GeneralSettingsComponent } from './GeneralSettings/GeneralSettings.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: SettingsComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'general',
        component: GeneralSettingsComponent,
      },
      {
        path: 'notifications',
        component: NotificationsComponent,
      },
      {
        path: 'security',
        component: SecurityComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SettingsRoutingModule { }
