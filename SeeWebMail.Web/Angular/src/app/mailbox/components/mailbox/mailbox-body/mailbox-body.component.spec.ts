import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MailboxBodyComponent } from './mailbox-body.component';

describe('MailboxBodyComponent', () => {
  let component: MailboxBodyComponent;
  let fixture: ComponentFixture<MailboxBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MailboxBodyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MailboxBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
