import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { TokenService } from './auth.service';

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

  // services/identity-api.service.ts
  login(req: LoginRequest) {
    const params = new HttpParams().set('useCookies', 'true');
    return this.http.post(`${this.base}/login`, req, {
      params,
      withCredentials: true,
    });
  }

  logout() {
    return this.http.post(`${this.base}/logout`, {}, { withCredentials: true });
  }

  getManageInfo() {
    return this.http.get<ManageInfo>(`${this.base}/manage/info`, {
      withCredentials: true,
    });
  }

  twoFa(cmd: TwoFaCommand) {
    return this.http.post(`${this.base}/manage/2fa`, cmd, {
      withCredentials: true,
    });
  }
}
