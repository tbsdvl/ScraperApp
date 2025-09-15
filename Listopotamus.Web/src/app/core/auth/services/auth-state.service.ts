import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, tap } from 'rxjs';
import { ManageInfo } from './identity-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthStateService {
  private _isAuth = new BehaviorSubject<boolean>(false);
  isAuth$ = this._isAuth.asObservable();

  constructor(private http: HttpClient) {}
  refresh() {
    return this.http
      .get<ManageInfo>('/identity/manage/info', { withCredentials: true })
      .pipe(
        tap((_) => this._isAuth.next(true)),
        catchError((_) => {
          this._isAuth.next(false);
          return of(null);
        })
      );
  }
}
