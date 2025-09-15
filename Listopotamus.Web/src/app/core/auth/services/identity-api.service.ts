import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenService } from './auth.service';
import { environment } from '../../../../environment';
import { Observable } from 'rxjs';

export interface LoginModel {
  email: string;
  password: string;
  twoFactorCode?: string;
  twoFactorRecoveryCode?: string;
}

export interface RegisterModel {
  email: string;
  password: string;
}

export interface ManageInfoModel {
  email: string;
  isEmailConfirmed: boolean;
  isTwoFactorEnabled: boolean;
  authenticatorKey?: string;
  recoveryCodesLeft?: number;
}

export interface ManageInfoResultModel {
  email: string;
}

export interface TwoFaCommand {
  action:
    | 'GenerateQrCode'
    | 'Enable'
    | 'Disable'
    | 'GenerateRecoveryCodes'
    | 'ResetAuthenticator';
  twoFactorCode?: string;
}

@Injectable({ providedIn: 'root' })
export class IdentityApiService {
  private base = environment.identityApiBaseUrl;

  constructor(private http: HttpClient, private tokens: TokenService) {}

  public register(req: RegisterModel): Observable<Object> {
    return this.http.post(`${this.base}/register`, req, {
      withCredentials: false,
    });
  }

  // services/identity-api.service.ts
  public login(req: LoginModel): Observable<Object> {
    const params = new HttpParams().set('useCookies', 'true');
    return this.http.post(`${this.base}/login`, req, {
      params,
      withCredentials: true,
    });
  }

  public logout(): Observable<Object> {
    return this.http.post(`${this.base}/logout`, {}, { withCredentials: true });
  }

  public getManageInfo(): Observable<ManageInfoResultModel> {
    return this.http.get<ManageInfoModel>(`${this.base}/manage/info`, {
      withCredentials: true,
    });
  }

  public twoFa(cmd: TwoFaCommand): Observable<Object> {
    return this.http.post(`${this.base}/manage/2fa`, cmd, {
      withCredentials: true,
    });
  }
}
