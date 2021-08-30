import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MailboxComponent } from './components/mailbox/mailbox.component';
import { SharedModule } from '@shared/shared.module';
import { MailboxToolbarComponent } from './components/mailbox/mailbox-toolbar/mailbox-toolbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MailboxListComponent } from './components/mailbox/mailbox-list/mailbox-list.component';
import { MailboxFoldersComponent } from './components/mailbox/mailbox-folders/mailbox-folders.component';
import { MailboxBodyComponent } from './components/mailbox/mailbox-body/mailbox-body.component';



@NgModule({
  declarations: [
    MailboxComponent,
    MailboxToolbarComponent,
    MailboxListComponent,
    MailboxFoldersComponent,
    MailboxBodyComponent
  ],
  imports: [
    CommonModule, SharedModule, FormsModule, ReactiveFormsModule
  ]
})
export class MailboxModule { }
