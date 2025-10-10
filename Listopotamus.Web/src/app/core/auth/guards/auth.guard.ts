import { Injectable } from "@angular/core";
import { CanActivate, Router, UrlTree } from "@angular/router";
import { IdentityApiService } from "../services/identity-api.service";
import { catchError, map, Observable, of } from "rxjs";

@Injectable({ providedIn: "root" })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: IdentityApiService
  ) {}

  private isSignedIn(): Observable<boolean> {
    return this.authService.getManageInfo().pipe(
      map((result) => {
        const valid = !!(result && result.email && result.email.length > 0);
        return valid;
      }),
      catchError(() => of(false))
    );
  }

  public canActivate(): Observable<boolean | UrlTree> {
    return this.isSignedIn().pipe(
      map((result) => {
        if (!result) {
          return this.router.createUrlTree(["/login"]);
        }

        return true;
      })
    );
  }
}
