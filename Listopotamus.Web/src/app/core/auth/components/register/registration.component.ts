import { Component } from "@angular/core";
import { BaseIdentityComponent } from "../base-identity/base-identity.component";
import { RegistrationModel } from "../../models/registration.model";

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
    // check if user is logged in
    this.identityApiService.manage2FA({})
      .subscribe({
        next: (result) => {
          if (result) {
            this.navigate(["dashboard"]);
          }
        },
        error: error => this.handleError(error, "Unable to login")
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
