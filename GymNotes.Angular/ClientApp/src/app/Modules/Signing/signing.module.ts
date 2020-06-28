import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './SignUp/SignUp.component';
import { SignInComponent } from './SignIn/SignIn.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MainPageComponent } from './MainPage/MainPage.component';
import { TermsOfServiceComponent } from './TermsOfService/TermsOfService.component';
import { PasswordResetEmailComponent } from './PasswordReset/PasswordResetEmail/PasswordResetEmail.component';
import { ResetPasswordComponent } from './PasswordReset/ResetPassword/ResetPassword.component';
import { PasswordResetedComponent } from './PasswordReset/PasswordReseted/PasswordReseted.component';
import { EmailConfirmationComponent } from './EmailConfirmation/EmailConfirmation/EmailConfirmation.component';
import { ConfirmationEmailSendedComponent } from './EmailConfirmation/ConfirmationEmailSended/ConfirmationEmailSended.component';
import { ResetPasswordEmailSentComponent } from './PasswordReset/ResetPasswordEmailSent/ResetPasswordEmailSent.component';

import { SigningRoutingModule } from './signing-routing.module';

@NgModule({
  declarations: [
    MainPageComponent,
    SignInComponent,
    SignUpComponent,
    TermsOfServiceComponent,
    PasswordResetEmailComponent,
    ResetPasswordComponent,
    PasswordResetedComponent,
    EmailConfirmationComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SigningRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    ConfirmationEmailSendedComponent,
    ResetPasswordEmailSentComponent,
    PasswordResetedComponent,
  ],
})
export class SigningModule { }
