import { Injectable } from '@angular/core';
import { HttpService } from '@shared/services/http.service';
import { Observable } from 'rxjs';
import { FolderContract } from '../models/mailbox.models';

@Injectable({
  providedIn: 'root'
})
export class MailboxService {

  constructor(private http: HttpService) { }

  getFolders(): Observable<FolderContract[]> {
    return this.http.get<FolderContract[]>('api/mailbox/folders');
  }
}
