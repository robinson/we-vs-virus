import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ResetPassword } from '../models/reset-password.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({ providedIn: 'root' })
export class SignUpService extends AbstractHttpService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(baseUrl + 'api/account');
  }

  confirmEmail(userId: string, token: string) {
    return this.http.get<any>(`${this.baseUrl}/confirmemail?userId=${userId}&token=${token}`);
  }

  resetPassword(model: ResetPassword) {
    return this.http.post<any>(`${this.baseUrl}/resetpassword`, model, this.httpOptions);
  }
}
