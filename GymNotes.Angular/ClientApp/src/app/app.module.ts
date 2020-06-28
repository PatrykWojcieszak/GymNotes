import { MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { A11yModule } from '@angular/cdk/a11y';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SelectBoxService } from './Services/Base/SelectBox.service';

import { UserOpinionService } from './Services/User/UserOpinion.service';
import { AuthInterceptor } from './Auth/auth.interceptor';
import { AuthenticationService } from './Services/Authentication/Authentication.service';
import { ChatService } from './Services/Chat/Chat.service';
import { UserSettingsService } from './Services/User/UserSettings.service';
import { UserInfoService } from './Services/User/UserInfo.service';
import { UserService } from './Services/User/User.service';
import { APIService } from './Services/API/API.service';

import { MainNavComponent } from './Components/main-nav/main-nav.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NotificationListComponent } from './Components/NotificationsGroup/NotificationList/NotificationList.component';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';

import { AppRoutingModule } from './app-routing.module';
import { AngularMaterialModule } from './angular-material.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainNavComponent,
    NotificationListComponent,
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
    AngularMaterialModule,
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
})
export class AppModule {}
