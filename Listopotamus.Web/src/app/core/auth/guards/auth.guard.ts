import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { TokenService } from '../services/token.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private tokens: TokenService,
    private router: Router,
  ) {}

  public canActivate(): boolean | UrlTree {
    if (this.tokens.accessToken) {
      return true;
    }

    return this.router.parseUrl('/login');
  }
}
