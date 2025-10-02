import { Component, inject } from "@angular/core";
import { catchError, of, switchMap } from "rxjs";

import { BaseIdentityComponent } from "../base-identity/base-identity.component";
import { AuthStateService } from "../../services/auth-state.service";

@Component({
  selector: "app-logout",
  templateUrl: "./logout.component.html",
  standalone: false,
})
export class LogoutComponent extends BaseIdentityComponent {
  private readonly authStateService = inject(AuthStateService);

  public hasAttempted = false;
  public lastAttemptFailed = false;

  protected override onInit(): void {
    this.performLogout();
  }

  public onSignOut(): void {
    if (this.isLoading) {
      return;
    }

    this.performLogout();
  }

  private performLogout(): void {
    this.hasAttempted = true;
    this.lastAttemptFailed = false;

    this.withLoading(
      this.identityApiService.logout().pipe(
        switchMap(() =>
          this.authStateService.refresh().pipe(
            catchError((error) => {
              this.handleError(
                error,
                "Unable to update authentication state after signing out."
              );
              return of(null);
            })
          )
        )
      )
    )
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.notifySuccess("Signed out successfully.");
          void this.navigate(["/login"]);
        },
        error: (error) => {
          this.lastAttemptFailed = true;
          this.handleError(error, "Unable to sign out.");
        },
      });
  }
}