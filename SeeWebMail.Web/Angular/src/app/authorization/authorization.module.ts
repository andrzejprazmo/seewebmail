import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorizeComponent } from './components/authorize/authorize.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AuthorizeComponent
  ],
  imports: [
    CommonModule
    , SharedModule
    , FormsModule
    , ReactiveFormsModule
    , TranslateModule.forChild()
  ]
})
export class AuthorizationModule { }
