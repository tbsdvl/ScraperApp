import { Component } from "@angular/core";
import { RegistrationModel } from "../../models/registration.model";
import { BaseComponent } from "../../../components/base/base.component";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  standalone: false,
})
export class RegistrationComponent extends BaseComponent {
  constructor() {
    super();
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
