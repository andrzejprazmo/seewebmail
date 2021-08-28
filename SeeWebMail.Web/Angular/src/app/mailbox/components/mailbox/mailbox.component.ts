import { Component, OnInit } from '@angular/core';
import { AuthorizeService, TokenContract } from '../../../authorization/services/authorize.service';
import { FolderContract } from '../../models/mailbox.models';
import { MailboxService } from '../../services/mailbox.service';

@Component({
  selector: 'app-mailbox',
  templateUrl: './mailbox.component.html',
  styleUrls: ['./mailbox.component.css']
})
export class MailboxComponent implements OnInit {

  folderList: FolderContract[] = [];

  public get currentUser(): TokenContract | null {
    return this.authService.getUser();
  }

  constructor(private authService: AuthorizeService, private mailboxService: MailboxService) { }

  ngOnInit(): void {
    this.mailboxService.getFolders().subscribe(result => {
      this.folderList = result;
      console.log(result);
    });
  }

}
