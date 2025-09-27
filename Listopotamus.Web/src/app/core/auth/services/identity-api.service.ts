import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../../../environment";
import { Observable } from "rxjs";
import { RegistrationModel } from "../models/registration.model";
import { LoginModel } from "../models/login.model";
import { Manage2FAInfoModel } from "../models/manage-2fa-info.model";
import { ManageInfoModel } from "../models/manage-info.model";
import { TwoFaCommand } from "../commands/two-fa.command";
import { Manage2FAModel } from "../models/manage-2fa.model";

@Injectable({ providedIn: "root" })
export class IdentityApiService {
  private base = environment.identityApiBaseUrl;

  constructor(private http: HttpClient) {}

  public register(body: RegistrationModel): Observable<Object> {
    return this.http.post(`${this.base}/register`, body, {
      withCredentials: false,
    });
  }

  public login(body: LoginModel): Observable<Object> {
    const params = new HttpParams().set("useCookies", "true");
    return this.http.post(`${this.base}/login`, body, {
      params,
      withCredentials: true,
    });
  }

  public logout(): Observable<Object> {
    return this.http.post(`${this.base}/logout`, {}, { withCredentials: true });
  }

  public getManageInfo(): Observable<ManageInfoModel> {
    return this.http.get<ManageInfoModel>(`${this.base}/manage/info`, {
      withCredentials: true,
    });
  }

  public manage2FA(body: Manage2FAModel | {}): Observable<Manage2FAInfoModel> {
    return this.http.post<Manage2FAInfoModel>(`${this.base}/manage/2fa`, body, {
      withCredentials: true,
    });
  }

  public twoFa(cmd: TwoFaCommand): Observable<Object> {
    return this.http.post(`${this.base}/manage/2fa`, cmd, {
      withCredentials: true,
    });
  }
}
