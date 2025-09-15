import {
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment';

@Injectable()
export class XsrfCrossOriginInterceptor implements HttpInterceptor {
  private getCookie(name: string) {
    const m = document.cookie.match(new RegExp(`(?:^|; )${name}=([^;]*)`));
    return m ? decodeURIComponent(m[1]) : null;
  }
  
  public intercept(req: HttpRequest<any>, next: HttpHandler) {
    const isCrossApi =
      req.url.startsWith(environment.identityApiBaseUrl) ||
      req.url.startsWith(environment.proxyApiBaseUrl);
    if (!isCrossApi) return next.handle(req);
    const token = this.getCookie('XSRF-TOKEN'); // server sets this
    return next.handle(
      token ? req.clone({ setHeaders: { 'X-XSRF-TOKEN': token } }) : req
    );
  }
}
