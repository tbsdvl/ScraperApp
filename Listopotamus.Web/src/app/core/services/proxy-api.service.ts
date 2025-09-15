import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProxyApiService {
  private base = environment.proxyApiBaseUrl;
  constructor(private http: HttpClient) {}
  
  public get<T>(path: string): Observable<T> {
    return this.http.get<T>(`${this.base}${path}`);
  }

  public post<T>(path: string, body: any): Observable<T> {
    return this.http.post<T>(`${this.base}${path}`, body);
  }

  public put<T>(path: string, body: any): Observable<T> {
    return this.http.put<T>(`${this.base}${path}`, body);
  }

  public delete<T>(path: string): Observable<T> {
    return this.http.delete<T>(`${this.base}${path}`);
  }
}
