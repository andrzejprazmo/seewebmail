import { Component, Input, OnInit } from '@angular/core';
import { MailBodyContract } from '@mailbox/models/mailbox.models';

@Component({
  selector: 'app-mailbox-body',
  templateUrl: './mailbox-body.component.html',
  styleUrls: ['./mailbox-body.component.css']
})
export class MailboxBodyComponent implements OnInit {
  @Input() mailBody!: MailBodyContract;

  constructor() { }

  ngOnInit(): void {
  }

}
