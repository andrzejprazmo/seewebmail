import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MailboxComponent } from './components/mailbox/mailbox.component';
import { SharedModule } from '@shared/shared.module';



@NgModule({
  declarations: [
    MailboxComponent
  ],
  imports: [
    CommonModule, SharedModule
  ]
})
export class MailboxModule { }
