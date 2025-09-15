import {
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment';

@Injectable()
export class CredentialsInterceptor implements HttpInterceptor {
  public intercept(req: HttpRequest<any>, next: HttpHandler) {
    const isApi =
      req.url.startsWith(environment.proxyApiBaseUrl) ||
      req.url.startsWith(environment.identityApiBaseUrl);
    return next.handle(isApi ? req.clone({ withCredentials: true }) : req);
  }
}
