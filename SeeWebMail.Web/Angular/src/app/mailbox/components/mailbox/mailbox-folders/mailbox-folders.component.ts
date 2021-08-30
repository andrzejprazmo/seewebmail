import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FolderContract } from '@mailbox/models/mailbox.models';

@Component({
  selector: 'app-mailbox-folders',
  templateUrl: './mailbox-folders.component.html',
  styleUrls: ['./mailbox-folders.component.css']
})
export class MailboxFoldersComponent implements OnInit {
  @Input() folders: FolderContract[] = []
  @Output() onFolderChange = new EventEmitter<string>();

  foldersForm = this.fb.group({
    folderName: ['']
  });
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.foldersForm.get('folderName')?.valueChanges.subscribe(val => {
      this.onFolderChange.emit(val);
    });
  }

}
