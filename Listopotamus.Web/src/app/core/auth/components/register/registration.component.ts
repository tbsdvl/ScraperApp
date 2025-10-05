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
    this.identityApiService
      .getManageInfo()
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next:(result) => {
          if (result) {
            this.navigate(["dashboard"]);
          }
        },
        error: error => this.handleError(error)
      });
  }

  public onSubmit(model: RegistrationModel): void {
    this.withLoading(this.identityApiService.register(model))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.notifySuccess("Registered successfully.");
          this.navigate(["dashboard"]);
        },
        error: error => this.handleError(error, "Unable to register.")
      })
  }
}
