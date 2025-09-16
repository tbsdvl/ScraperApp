import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { MonoTypeOperatorFunction, Observable, Subject, takeUntil } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ProxyApiService } from '../../services/proxy-api.service';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-base',
  template: ''
})
export abstract class BaseComponent implements OnInit, OnDestroy {
  protected readonly proxyService = inject(ProxyApiService);
  protected readonly notificationService = inject(NotificationService);
  protected readonly router = inject(Router);
  protected readonly route = inject(ActivatedRoute);

  protected readonly destroy$ = new Subject<void>();
  public isLoading = false;

  public ngOnInit(): void {
    this.onInit();
  }

  public ngOnDestroy(): void {
    this.onDestroy();
    this.destroy$.next();
    this.destroy$.complete();
  }

  protected onInit(): void {}

  protected onDestroy(): void {}

  protected startLoading(): void {
    this.isLoading = true;
  }

  protected stopLoading(): void {
    this.isLoading = false;
  }

  protected withLoading<T>(operation: Observable<T>): Observable<T> {
    this.startLoading();
    return operation.pipe(finalize(() => this.stopLoading()));
  }

  protected takeUntilDestroyed<T>(): MonoTypeOperatorFunction<T> {
    return takeUntil(this.destroy$);
  }

  protected navigate(
    commands: any[],
    extras?: NavigationExtras
  ): Promise<boolean> {
    return this.router.navigate(commands, extras);
  }

  protected getRouteParam(name: string): string | null {
    return this.route.snapshot.paramMap.get(name);
  }

  protected getQueryParam(name: string): string | null {
    return this.route.snapshot.queryParamMap.get(name);
  }

  protected handleError(
    error: unknown,
    fallbackMessage = 'An unexpected error occurred.'
  ): void {
    console.error(error);
    this.notificationService.showError(fallbackMessage, error);
  }

  protected notifySuccess(message: string): void {
    this.notificationService.showSuccess(message);
  }

  protected notifyInfo(message: string): void {
    this.notificationService.showInfo(message);
  }

  protected notifyWarning(message: string): void {
    this.notificationService.showWarning(message);
  }

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
