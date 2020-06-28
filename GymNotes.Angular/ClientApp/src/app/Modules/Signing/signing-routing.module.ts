import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TermsOfServiceComponent } from './TermsOfService/TermsOfService.component';
import { MainPageComponent } from './MainPage/MainPage.component';
import { EmailConfirmationComponent } from './EmailConfirmation/EmailConfirmation/EmailConfirmation.component';
import { PasswordResetEmailComponent } from './PasswordReset/PasswordResetEmail/PasswordResetEmail.component';
import { ResetPasswordComponent } from './PasswordReset/ResetPassword/ResetPassword.component';
import { SignUpComponent } from './SignUp/SignUp.component';
import { SignInComponent } from './SignIn/SignIncomponent';

const routes: Routes = [
  {
    path: '',
    component: MainPageComponent,
    children: [
      { path: 'registration', component: SignUpComponent },
      { path: 'login', component: SignInComponent },
    ],
  },
  { path: 'emailConfirmation', component: EmailConfirmationComponent },
  { path: 'forgotPasswordEmail', component: PasswordResetEmailComponent },
  { path: 'forgotPassword', component: ResetPasswordComponent },
  { path: 'terms', component: TermsOfServiceComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SigningRoutingModule { }
