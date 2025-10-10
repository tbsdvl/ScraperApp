import { Component } from "@angular/core";

import { LoginModel } from "../../models/login.model";
import { BaseComponent } from "../../../components/base/base.component";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  standalone: false,
})
export class LoginComponent extends BaseComponent {
  public loaded = false;
  public showTwoFactorCodeControl: boolean = false;

  public onSubmit(model: LoginModel): void {
    this.identityApiService.login(model)
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.notifySuccess("Signed in successfully.");
          this.navigate([""]);
        },
        error: error => this.handleError(error, "Unable to sign in."),
      });
  }
}
