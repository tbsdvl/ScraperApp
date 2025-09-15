import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { TokenService } from '../services/token.service';
import { catchError, switchMap } from 'rxjs/operators';
import { IdentityApiService } from '../services/identity-api.service';
import { environment } from '../../../environment';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private tokens: TokenService,
    private identity: IdentityApiService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const isIdentity = req.url.startsWith(environment.identityApiBaseUrl);
    const isProxy = req.url.startsWith(environment.proxyApiBaseUrl);

    // Attach token for proxy and any secured APIs, but not for login/register
    let authReq = req;
    const token = this.tokens.accessToken;
    if (token && (isProxy || (!isIdentity && req.withCredentials !== true))) {
      authReq = req.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
    }

    return next.handle(authReq).pipe(
      catchError((err: any) => {
        if (
          err instanceof HttpErrorResponse &&
          err.status === 401 &&
          this.tokens.auth
        ) {
          // Attempt refresh once
          if (
            this.tokens.needsRefresh(3600) ||
            err.error?.message === 'token_expired'
          ) {
            return this.identity.refresh().pipe(
              switchMap(() => {
                const newToken = this.tokens.accessToken;
                const retried = authReq.clone({
                  setHeaders: newToken
                    ? { Authorization: `Bearer ${newToken}` }
                    : {},
                });
                return next.handle(retried);
              })
            );
          }
        }

        return throwError(() => err);
      })
    );
  }
}
