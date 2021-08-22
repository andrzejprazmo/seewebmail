import { Inject, Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { OperationResult } from '@shared/models/operation-result';
import { HttpService } from '@shared/services/http.service';


export interface LoginContract {
  emailAddress: string;
  password: string;
  rememberMe: boolean;
}

export interface TokenContract {
  userEmail: string;
  token: string;
  isAdmin: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  constructor(public jwtHelper: JwtHelperService, private http: HttpService, @Inject('BASE_URL') private baseUrl: string) { }

  public isAuthenticated(): boolean {
    const currentUser = this.getUser();
    if (currentUser) {
      return !this.jwtHelper.isTokenExpired(currentUser.token);
    }
    return false;
  }

  public signIn(model: LoginContract): Observable<OperationResult<TokenContract>> {
    return this.http.post<OperationResult<TokenContract>>(this.baseUrl + 'api/authorize/login', model).pipe(map(data => {
      if (!data.hasErrors && data.value) {
        localStorage.setItem('currentUser', JSON.stringify(data.value));
      }
      return data;
    }));
  }

  public getUser(): TokenContract | null {
    const data = localStorage.getItem('currentUser');
    if (data) {
      return JSON.parse(data) as TokenContract;
    }
    return null;
  }

  public signOut() {
    if (this.getUser()) {
      localStorage.removeItem('currentUser');
    }
  }
}

