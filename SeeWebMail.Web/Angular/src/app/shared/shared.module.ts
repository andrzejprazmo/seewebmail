import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AuthorizeComponent } from '../authorization/components/authorize/authorize.component';
import { MailboxComponent } from '../mailbox/components/mailbox/mailbox.component';
import { AuthGuardService as AuthGuard } from '../authorization/services/auth-guard.service';
import { ValidationErrorComponent } from './components/validation-error/validation-error.component';
import { ApplicationMenuComponent } from './components/application-menu/application-menu.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: AuthorizeComponent },
  { path: 'logout', redirectTo: '/login' },
  { path: 'mailbox', component: MailboxComponent , canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [
    ValidationErrorComponent,
    ApplicationMenuComponent
  ],
  imports: [
    CommonModule
    , HttpClientModule
    , RouterModule.forRoot(routes)
    , JwtModule.forRoot({
      config: {
        tokenGetter: function () {
          return localStorage.getItem('token');
        }
      }
    })
  ],
  exports: [RouterModule, ValidationErrorComponent, ApplicationMenuComponent],
  providers: [AuthGuard, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  schemas: []
})
export class SharedModule { }
