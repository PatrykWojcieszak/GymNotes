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
import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AuthenticationService } from './Auth/Authentication.service';
import { UserService } from './Core/Services/Http/User/User.service';
import { UserOpinionService } from './Core/Services/Http/User/UserOpinion.service';
import { UserInfoService } from './Core/Services/Http/User/UserInfo.service';
import { UserSettingsService } from './Core/Services/Http/User/UserSettings.service';
import { ChatService } from './Core/Services/Http/Chat/Chat.service';
import { APIService } from './Core/Services/Http/API/API.service';
import { AuthInterceptor } from './Auth/auth.interceptor';
import { SelectBoxService } from './Core/Services/Utility/SelectBox.service';
import { GlobalErrorHandlerService } from './Core/Services/Error Handling/GlobalErrorHandler.service';

import { MainNavComponent } from './Components/main-nav/main-nav.component';
import { AppComponent } from './app.component';
import { NotificationListComponent } from './Components/NotificationsGroup/NotificationList/NotificationList.component';
import { HomeLayoutComponent } from './Layouts/Home-layout.component';
import { LoginLayoutComponent } from './Layouts/Login-layout.component';

import { AppRoutingModule } from './app-routing.module';
import { AngularMaterialModule } from './angular-material.module';
import { ServerErrorInterceptorService } from './Core/Services/Error Handling/ServerErrorInterceptor.service';

@NgModule({
	declarations: [
		AppComponent,
		MainNavComponent,
		NotificationListComponent,
		HomeLayoutComponent,
		LoginLayoutComponent
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
		NgbModule
	],
	exports: [ RouterModule ],
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
			multi: true
		},
		{
			provide: HTTP_INTERCEPTORS,
			useClass: ServerErrorInterceptorService,
			multi: true
		},
		{ provide: ErrorHandler, useClass: GlobalErrorHandlerService }
	],
	bootstrap: [ AppComponent ]
})
export class AppModule {}
