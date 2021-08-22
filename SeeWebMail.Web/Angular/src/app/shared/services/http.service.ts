import { HttpClient, HttpContext, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DOCUMENT } from '@angular/common';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient, @Inject(DOCUMENT) private document: Document) { }

  public get<T>(url: string, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    context?: HttpContext;
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean>;
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.showSpinner();
    return this.http.get<T>(url, options).pipe(map(result => {
      this.hideSpinner();
      return result;
    }));
  }

  public post<T>(url: string, body: any, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    context?: HttpContext;
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean>;
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.showSpinner();
    return this.http.post<T>(url, body, options).pipe(map(result => {
      this.hideSpinner();
      return result;
    }));
  }

  private showSpinner() {
    var spinner = this.document.getElementById('loading-spinner');
    if (spinner) {
      spinner.style.display = 'block';
    }
  }

  private hideSpinner() {
    var spinner = this.document.getElementById('loading-spinner');
    if (spinner) {
      spinner.style.display = 'none';
    }
  }
}
