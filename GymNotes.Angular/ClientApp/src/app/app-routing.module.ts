import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { AuthGuard } from './Auth/auth.guard';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';
import { LoginComponent } from './Components/Login_Registration/Login/Login.component';
import { MainPageComponent } from './Components/Login_Registration/MainPage/MainPage.component';
import { RegistrationComponent } from './Components/Login_Registration/Registration/Registration.component';
import { NotificationListComponent } from './Components/NotificationsGroup/NotificationList/NotificationList.component';
import { EmailConfirmationComponent } from './Components/Login_Registration/EmailConfirmation/EmailConfirmation/EmailConfirmation.component';
import { PasswordResetEmailComponent } from './Components/Login_Registration/PasswordReset/PasswordResetEmail/PasswordResetEmail.component';
import { ResetPasswordComponent } from './Components/Login_Registration/PasswordReset/ResetPassword/ResetPassword.component';
import { TermsOfServiceComponent } from './Components/TermsOfService/TermsOfService.component';

const routes: Routes = [
  {
    path: '',
    component: HomeLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'tools',
        loadChildren: () => import('./Modules/Tools/tools.module')
        .then(m => m.ToolsModule)
      },
      {
        path: 'settings',
        loadChildren: () => import('./Modules/Settings/settings.module')
        .then(m => m.SettingsModule)
      },
      { path: 'calendar',
        loadChildren: () => import('./Modules/Training History/trainingHistory.module')
        .then(m => m.TrainingHistoryModule)
      },
      { path: 'training-list',
        loadChildren: () => import('./Modules/Training Plan/trainingPlan.module')
        .then(m => m.TrainingPlanModule)
      },
      { path: 'chat',
        loadChildren: () => import('./Modules/Chat/chat.module')
        .then(m => m.ChatModule)
      },
      {
        path: 'userList',
        loadChildren: () => import('./Modules/User/user.module')
        .then(m => m.UserModule)
      },
      {
        path: 'statistics',
        loadChildren: () => import('./Modules/Statistics/statistics.module')
        .then(m => m.StatisticsModule)
      },
      { path: 'notifications', component: NotificationListComponent, canActivate: [AuthGuard] },

    ],
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'user',
        component: MainPageComponent,
        children: [
          { path: 'registration', component: RegistrationComponent },
          { path: 'login', component: LoginComponent },
        ],
      },
    ]
  },
  { path: 'emailConfirmation', component: EmailConfirmationComponent },
  { path: 'forgotPasswordEmail', component: PasswordResetEmailComponent },
  { path: 'forgotPassword', component: ResetPasswordComponent },
  { path: 'terms', component: TermsOfServiceComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
