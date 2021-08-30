import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MailboxFoldersComponent } from './mailbox-folders.component';

describe('MailboxFoldersComponent', () => {
  let component: MailboxFoldersComponent;
  let fixture: ComponentFixture<MailboxFoldersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MailboxFoldersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MailboxFoldersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
