import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AuthorizeComponent } from '../authorization/components/authorize/authorize.component';
import { MailboxComponent } from '../mailbox/components/mailbox/mailbox.component';
import { AuthGuardService as AuthGuard } from '../authorization/services/auth-guard.service';
import { ValidationErrorComponent } from './components/validation-error/validation-error.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: AuthorizeComponent },
  { path: 'mailbox', component: MailboxComponent , canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [
    ValidationErrorComponent
  ],
  imports: [
    CommonModule
    , RouterModule.forRoot(routes)
    , JwtModule.forRoot({
      config: {
        tokenGetter: function () {
          return localStorage.getItem('token');
        }
      }
    })
  ],
  exports: [RouterModule, ValidationErrorComponent],
  providers: [AuthGuard]
})
export class SharedModule { }
