import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { IdentityApiService } from "../services/identity-api.service";
import { map, Observable } from "rxjs";

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
      })
    );
  }

  public canActivate(): Observable<boolean> {
    return this.isSignedIn().pipe(
      map((result) => {
        if (!result) {
          this.router.parseUrl("/login");

          return false;
        }

        return true;
      })
    );
  }
}
