import { Injectable } from '@angular/core';
import { HttpService } from '@shared/services/http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MailboxService {

  constructor(private http: HttpService) { }

  getFolders(): Observable<string[]> {
    return this.http.get<string[]>('api/mailbox/folders');
  }
}
