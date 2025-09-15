import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProxyApiService {
  private base = environment.proxyApiBaseUrl;
  constructor(private http: HttpClient) {}

  public get<T>(path: string): Observable<T> {
    return this.http.get<T>(`${this.base}${path}`, { withCredentials: true });
  }

  public post<T>(path: string, b: any): Observable<T> {
    return this.http.post<T>(`${this.base}${path}`, b, {
      withCredentials: true,
    });
  }

  public put<T>(path: string, b: any): Observable<T> {
    return this.http.put<T>(`${this.base}${path}`, b, {
      withCredentials: true,
    });
  }

  public delete<T>(path: string): Observable<T> {
    return this.http.delete<T>(`${this.base}${path}`, {
      withCredentials: true,
    });
  }
}
