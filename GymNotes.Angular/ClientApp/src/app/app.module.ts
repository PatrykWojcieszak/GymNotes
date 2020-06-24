import { ToolsModule } from './Modules/Tools/tools.module';
import { ChatService } from './Services/Chat/Chat.service';
import { UserSettingsService } from './Services/User/UserSettings.service';
import { SecurityComponent } from './Components/User/Settings/Security/Security.component';
import { UserProfileEditAchievementsComponent } from './Components/User/UserProfileEditingGroup/UserProfileEditAchievements/UserProfileEditAchievements.component';
import { PasswordResetedComponent } from './Components/Login_Registration/PasswordReset/PasswordReseted/PasswordReseted.component';
import { ResetPasswordEmailSentComponent } from './Components/Login_Registration/PasswordReset/ResetPasswordEmailSent/ResetPasswordEmailSent.component';
import { TermsOfServiceComponent } from './Components/TermsOfService/TermsOfService.component';
import { NotificationsComponent } from './Components/User/Settings/Notifications/Notifications.component';
import { TrainingListComponent } from './Components/TrainingPlan/TrainingList/TrainingList.component';
import { NotFoundComponent } from './Components/Main/NotFound/NotFound.component';
import { UserProfileEditingComponent } from './Components/User/UserProfileEditingGroup/UserProfileEditing/UserProfileEditing.component';
import { UserProfileComponent } from './Components/User/UserProfile/UserProfile.component';
import { SettingsComponent } from './Components/User/Settings/Settings/Settings.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { UserService } from './Services/User/User.service';
import { APIService } from './Services/API/API.service';
import { CommonModule } from '@angular/common';
import { A11yModule } from '@angular/cdk/a11y';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './Components/Login_Registration/Login/Login.component';
import { RegistrationComponent } from './Components/Login_Registration/Registration/Registration.component';
import { MainPageComponent } from './Components/Login_Registration/MainPage/MainPage.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EmailConfirmationComponent } from './Components/Login_Registration/EmailConfirmation/EmailConfirmation/EmailConfirmation.component';
import { ConfirmationEmailSendedComponent } from './Components/Login_Registration/EmailConfirmation/ConfirmationEmailSended/ConfirmationEmailSended.component';
import { AuthenticationService } from './Services/Authentication/Authentication.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PasswordResetEmailComponent } from './Components/Login_Registration/PasswordReset/PasswordResetEmail/PasswordResetEmail.component';
import { ResetPasswordComponent } from './Components/Login_Registration/PasswordReset/ResetPassword/ResetPassword.component';
import { UserListComponent } from './Components/User/UserList/UserList.component';
import { GeneralSettingsComponent } from './Components/User/Settings/GeneralSettings/GeneralSettings.component';
import { MainNavComponent } from './Components/main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { AddTrainingPlanComponent } from './Components/TrainingPlan/AddTrainingPlan/AddTrainingPlan.component';
import { AuthGuard } from './Auth/auth.guard';
import { AuthInterceptor } from './Auth/auth.interceptor';
import { Calendar } from './Components/TrainingHistory/Calendar/Calendar.component';
import { AddTrainingToCalendarComponent } from './Components/TrainingHistory/AddTrainingToCalendar/AddTrainingToCalendar.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StatisticsListComponent } from './Components/User/Statistics/StatisticsList/StatisticsList.component';
import { AddDisciplineComponent } from './Components/User/Statistics/AddDiscipline/AddDiscipline.component';
import { AddOpinionComponent } from './Components/User/AddOpinion/AddOpinion.component';
import { UserOpinionService } from './Services/User/UserOpinion.service';
import { UserInfoService } from './Services/User/UserInfo.service';
import { SelectBoxService } from './Services/Base/SelectBox.service';
import { NotificationListComponent } from './Components/NotificationsGroup/NotificationList/NotificationList.component';
import { ChatListComponent } from './Components/Chat/ChatList/ChatList.component';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainPageComponent,
    LoginComponent,
    RegistrationComponent,
    EmailConfirmationComponent,
    UserListComponent,
    SettingsComponent,
    GeneralSettingsComponent,
    UserProfileComponent,
    UserProfileEditingComponent,
    MainNavComponent,
    MainNavComponent,
    NotFoundComponent,
    TrainingListComponent,
    AddTrainingPlanComponent,
    ChatListComponent,
    NotificationsComponent,
    TermsOfServiceComponent,
    PasswordResetEmailComponent,
    ResetPasswordComponent,
    PasswordResetedComponent,
    UserProfileEditAchievementsComponent,
    AddTrainingToCalendarComponent,
    Calendar,
    StatisticsListComponent,
    AddDisciplineComponent,
    AddOpinionComponent,
    NotificationListComponent,
    SecurityComponent,
    HomeLayoutComponent,
    LoginLayoutComponent,
	],
	imports: [
    BrowserModule,
    AppRoutingModule,
		A11yModule,
    ClipboardModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    PortalModule,
    ScrollingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    MatDialogModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
    LayoutModule,
    RouterModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    NgbModule,
  ],
  exports: [RouterModule],
  providers: [
    AuthenticationService,
    UserService,
    UserOpinionService,
    UserInfoService,
    SelectBoxService,
    UserSettingsService,
    ChatService,
    APIService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ConfirmationEmailSendedComponent,
    UserProfileEditingComponent,
    ResetPasswordEmailSentComponent,
    PasswordResetedComponent,
    UserProfileEditAchievementsComponent,
    AddTrainingToCalendarComponent,
    AddOpinionComponent,
  ],
})
export class AppModule {}
