import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environment';
import { Observable } from 'rxjs';
import { RegisterModel } from '../models/register.model';
import { LoginModel } from '../models/login.model';
import { ManageInfoResultModel } from '../models/manage-info-result.model';
import { ManageInfoModel } from '../models/manage-info.model';
import { TwoFaCommand } from '../commands/two-fa.command';

@Injectable({ providedIn: 'root' })
export class IdentityApiService {
  private base = environment.identityApiBaseUrl;

  constructor(private http: HttpClient) {}

  public register(body: RegisterModel): Observable<Object> {
    return this.http.post(`${this.base}/register`, body, {
      withCredentials: false,
    });
  }

  public login(body: LoginModel): Observable<Object> {
    const params = new HttpParams().set('useCookies', 'true');
    return this.http.post(`${this.base}/login`, body, {
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
