import { inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ProxyApiService } from '../../services/proxy-api.service';

export abstract class BaseComponent {
  protected proxyService = inject(ProxyApiService);

  protected get<T>(path: string): Observable<T> {
    return this.proxyService.get<T>(path);
  }
  protected post<T>(path: string, body: unknown): Observable<T> {
    return this.proxyService.post<T>(path, body);
  }
  protected put<T>(path: string, body: unknown): Observable<T> {
    return this.proxyService.put<T>(path, body);
  }
  protected delete<T>(path: string): Observable<T> {
    return this.proxyService.delete<T>(path);
  }
}
