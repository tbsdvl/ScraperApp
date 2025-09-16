import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, of, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ManageInfoModel } from '../models/manage-info.model';

@Injectable({ providedIn: 'root' })
export class AuthStateService {
  private _isAuth = new BehaviorSubject<boolean>(false);
  isAuth$ = this._isAuth.asObservable();

  constructor(private http: HttpClient) {}

  public refresh() {
    return this.http
      .get<ManageInfoModel>('/identity/manage/info', { withCredentials: true })
      .pipe(
        tap((_) => this._isAuth.next(true)),
        catchError((_) => {
          this._isAuth.next(false);
          return of(null);
        })
      );
  }
}
