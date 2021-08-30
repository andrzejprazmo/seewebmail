import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-mailbox-toolbar',
  templateUrl: './mailbox-toolbar.component.html',
  styleUrls: ['./mailbox-toolbar.component.css']
})
export class MailboxToolbarComponent implements OnInit {
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }
}
