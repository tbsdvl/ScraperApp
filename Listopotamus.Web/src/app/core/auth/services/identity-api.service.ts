import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from '../../../environment';
import { TokenService } from './auth.service';
import { AccessTokenResponse } from './token.service';

export interface LoginRequest {
  email: string;
  password: string;
  twoFactorCode?: string; // when 2FA enabled
  twoFactorRecoveryCode?: string; // alternative
}

export interface RegisterRequest {
  email: string;
  password: string;
}

export interface ManageInfo {
  email: string;
  isEmailConfirmed: boolean;
  isTwoFactorEnabled: boolean;
  authenticatorKey?: string;
  recoveryCodesLeft?: number;
}

export interface TwoFaCommand {
  // action values per Identity API: 'GenerateQrCode', 'Enable', 'Disable', 'GenerateRecoveryCodes', etc.
  // The docs show POST /manage/2fa with a command discriminator.
  // We'll model a flexible DTO. See server implementation for exact names.
  action:
    | 'GenerateQrCode'
    | 'Enable'
    | 'Disable'
    | 'GenerateRecoveryCodes'
    | 'ResetAuthenticator';
  twoFactorCode?: string; // required when enabling
}

@Injectable({ providedIn: 'root' })
export class IdentityApiService {
  private base = environment.identityApiBaseUrl; // e.g., '' or '/identity'

  constructor(private http: HttpClient, private tokens: TokenService) {}

  register(req: RegisterRequest) {
    return this.http.post(`${this.base}/register`, req, {
      withCredentials: false,
    });
  }

  login(
    req: LoginRequest,
    useCookies = false
  ): Observable<AccessTokenResponse | string> {
    const params = new HttpParams().set('useCookies', String(useCookies));
    return this.http
      .post<AccessTokenResponse | string>(`${this.base}/login`, req, { params })
      .pipe(
        tap((res) => {
          if (!useCookies && typeof res === 'object' && 'accessToken' in res) {
            this.tokens.auth = {
              token: res as AccessTokenResponse,
              acquiredAt: Date.now(),
              email: req.email,
            };
          }
        })
      );
  }

  refresh(): Observable<AccessTokenResponse> {
    const current = this.tokens.auth;
    if (!current) throw new Error('Not authenticated');
    return this.http
      .post<AccessTokenResponse>(`${this.base}/refresh`, {
        refreshToken: current.token.refreshToken,
      })
      .pipe(
        tap(
          (t) =>
            (this.tokens.auth = {
              token: t,
              acquiredAt: Date.now(),
              email: current.email,
            })
        )
      );
  }

  logout() {
    this.tokens.clear();
    // If you added a server /logout cookie endpoint, call it too.
    return this.http.post(`${this.base}/logout`, {});
  }

  getManageInfo(): Observable<ManageInfo> {
    return this.http.get<ManageInfo>(`${this.base}/manage/info`);
  }

  updateManageInfo(info: Partial<ManageInfo>) {
    return this.http.post(`${this.base}/manage/info`, info);
  }

  twoFa(cmd: TwoFaCommand): Observable<any> {
    return this.http.post(`${this.base}/manage/2fa`, cmd);
  }
}
