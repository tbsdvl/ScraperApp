import { Component } from "@angular/core";
import { BaseIdentityComponent } from "../base-identity/base-identity.component";
import { RegistrationModel } from "../../models/registration.model";
import { catchError, of } from "rxjs";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  standalone: false,
})
export class RegistrationComponent extends BaseIdentityComponent {
  constructor() {
    super();
  }

  public override ngOnInit(): void {
    this.identityApiService
      .getManageInfo()
      .pipe(
        this.takeUntilDestroyed(),
        catchError((error: unknown) => {
          if (error instanceof HttpErrorResponse && error.status === 401) {
            return of(null);
          }

          this.handleError(error, "Unable to verify authentication state.");
          return of(null);
        })
      )
      .subscribe((result) => {
        if (result) {
          this.navigate(["dashboard"]);
        }
      });
  }

  public onSubmit(model: RegistrationModel): void {
    this.withLoading(this.identityApiService.register(model))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.notifySuccess("Registered successfully.");
        },
        error: error => this.handleError(error, "Unable to register.")
      })
  }
}
