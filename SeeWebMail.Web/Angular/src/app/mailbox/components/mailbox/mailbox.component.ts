import { Component, OnInit } from '@angular/core';
import { AuthorizeService, TokenContract } from '@auth/services/authorize.service';
import { FolderContract, MailBodyContract, MailHeaderContract } from '@mailbox/models/mailbox.models';
import { MailboxService } from '@mailbox/services/mailbox.service';

@Component({
  selector: 'app-mailbox',
  templateUrl: './mailbox.component.html',
  styleUrls: ['./mailbox.component.css']
})
export class MailboxComponent implements OnInit {

  folderList: FolderContract[] = [];
  mailItemList: MailHeaderContract[] = [];
  currentFolderName: string = '';
  currentMailBody!: MailBodyContract;

  public get currentUser(): TokenContract | null {
    return this.authService.getUser();
  }

  constructor(private authService: AuthorizeService, private mailboxService: MailboxService) { }

  ngOnInit(): void {
    this.mailboxService.getFolders().subscribe(result => {
      this.folderList = result;
    });
  }

  onFolderChange(folderName: string) {
    this.currentFolderName = folderName;
    this.mailboxService.getMailHeaders(folderName).subscribe(result => {
      this.mailItemList = result.list;
    });
  }

  onMailSelected(mailItem: MailHeaderContract) {
    this.mailboxService.getMailBody(this.currentFolderName, mailItem.index).subscribe(result => {
      this.currentMailBody = result;
    });
  }
}
