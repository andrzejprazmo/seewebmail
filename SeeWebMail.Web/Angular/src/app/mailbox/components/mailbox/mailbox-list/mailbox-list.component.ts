import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MailHeaderContract } from '../../../models/mailbox.models';

@Component({
  selector: 'app-mailbox-list',
  templateUrl: './mailbox-list.component.html',
  styleUrls: ['./mailbox-list.component.css']
})
export class MailboxListComponent implements OnInit {
  @Input() items: MailHeaderContract[] = []
  @Output() onMailSelected = new EventEmitter<MailHeaderContract>();

  constructor() { }

  ngOnInit(): void {
  }

  onItemSelected(item: MailHeaderContract) {
    this.onMailSelected.emit(item);
  }
}
