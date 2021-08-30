import { Injectable } from '@angular/core';
import { HttpService } from '@shared/services/http.service';
import { Observable } from 'rxjs';
import { FolderContract, MailPackageContract, MailBodyContract } from '../models/mailbox.models';

@Injectable({
  providedIn: 'root'
})
export class MailboxService {

  constructor(private http: HttpService) { }

  getFolders(): Observable<FolderContract[]> {
    return this.http.get<FolderContract[]>('api/mailbox/folders');
  }

  getMailHeaders(folderName: string): Observable<MailPackageContract> {
    return this.http.get<MailPackageContract>('api/mailbox/headers', { params: { 'folderName': folderName } });
  }

  getMailBody(folderName: string, mailIndex: number): Observable<MailBodyContract> {
    return this.http.get<MailBodyContract>('api/mailbox/body', {
      params: {
        'folderName': folderName, 'mailIndex': mailIndex
      }
    });
  }
}
