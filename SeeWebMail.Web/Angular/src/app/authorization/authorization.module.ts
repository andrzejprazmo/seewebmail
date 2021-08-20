import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorizeComponent } from './components/authorize/authorize.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';


@NgModule({
  declarations: [
    AuthorizeComponent
  ],
  imports: [
    CommonModule, FormsModule
    , ReactiveFormsModule
    , TranslateModule.forChild()
  ]
})
export class AuthorizationModule { }
