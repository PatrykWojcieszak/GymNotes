import { UserListComponent } from './Components/User/UserList/UserList.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { AuthGuard } from './Auth/auth.guard';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';
import { LoginComponent } from './Components/Login_Registration/Login/Login.component';
import { MainPageComponent } from './Components/Login_Registration/MainPage/MainPage.component';
import { RegistrationComponent } from './Components/Login_Registration/Registration/Registration.component';
import { UserProfileComponent } from './Components/User/UserProfile/UserProfile.component';
import { TrainingListComponent } from './Components/TrainingPlan/TrainingList/TrainingList.component';
import { AddTrainingPlanComponent } from './Components/TrainingPlan/AddTrainingPlan/AddTrainingPlan.component';
import { ChatListComponent } from './Components/Chat/ChatList/ChatList.component';
import { NotificationListComponent } from './Components/NotificationsGroup/NotificationList/NotificationList.component';
import { StatisticsListComponent } from './Components/User/Statistics/StatisticsList/StatisticsList.component';
import { AddDisciplineComponent } from './Components/User/Statistics/AddDiscipline/AddDiscipline.component';
import { SettingsComponent } from './Components/User/Settings/Settings/Settings.component';
import { GeneralSettingsComponent } from './Components/User/Settings/GeneralSettings/GeneralSettings.component';
import { NotificationsComponent } from './Components/User/Settings/Notifications/Notifications.component';
import { SecurityComponent } from './Components/User/Settings/Security/Security.component';
import { Calendar } from './Components/TrainingHistory/Calendar/Calendar.component';
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
        path: '',
        redirectTo: '/userList', pathMatch: 'full'
      },
      {
        path: 'tools',
        loadChildren: () => import('./Modules/Tools/tools.module')
        .then(m => m.ToolsModule)
      },
      {
        path: 'userList',
        component: UserListComponent,
      },
      {
        path: 'userprofile',
        component: UserProfileComponent,
      },
      {
        path: 'training-list',
        component: TrainingListComponent,
      },
      {
        path: 'add-training-plan',
        component: AddTrainingPlanComponent,
      },
      {
        path: 'chat',
        component: ChatListComponent,
      },
      {
        path: 'chat/:id',
        component: ChatListComponent,
      },
      { path: 'notifications', component: NotificationListComponent, canActivate: [AuthGuard] },
      { path: 'statistics',
        component: StatisticsListComponent,
        canActivate: [ AuthGuard ],
        children: [
          { path: 'add-discipline', component: AddDisciplineComponent, canActivate: [ AuthGuard ]},
        ]
      },
      {
        path: 'settings',
        component: SettingsComponent,
        canActivate: [AuthGuard],
        children: [
          {
            path: 'general',
            component: GeneralSettingsComponent,
            canActivate: [AuthGuard],
          },
          {
            path: 'notifications',
            component: NotificationsComponent,
            canActivate: [AuthGuard],
          },
          {
            path: 'security',
            component: SecurityComponent,
            canActivate: [AuthGuard],
          },
        ],
      },
      { path: 'calendar', component: Calendar, canActivate: [AuthGuard] },
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
