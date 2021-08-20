import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { OperationResult } from '@shared/models/operation-result';


export interface LoginContract {
  emailAddress: string;
  password: string;
  rememberMe: boolean;
}

export interface UserContract {
  userId: string;
  userEmail: string;
  token: string;
}



@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  constructor(public jwtHelper: JwtHelperService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public isAuthenticated(): boolean {
    const data = localStorage.getItem('currentUser');
    if (data) {
      const currentUser = JSON.parse(data) as UserContract;
      return !this.jwtHelper.isTokenExpired(currentUser.token);
    }
    return false;
  }

  public signIn(model: LoginContract): Observable<OperationResult<UserContract>> {
    return this.http.post<OperationResult<UserContract>>(this.baseUrl + 'api/authorize/login', model).pipe(map(data => {
      if (!data.hasErrors && data.value) {
        localStorage.setItem('currentUser', JSON.stringify(data.value));
      }
      return data;
    }));
  }
}

