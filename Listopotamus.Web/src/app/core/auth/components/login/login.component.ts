import { Component } from "@angular/core";

import { LoginModel } from "../../models/login.model";
import { BaseIdentityComponent } from "../base-identity/base-identity.component";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  standalone: false,
})
export class LoginComponent extends BaseIdentityComponent {
  public loaded = false;
  public showTwoFactorCodeControl: boolean = false;

  public override ngOnInit(): void {
    this.withLoading(this.identityApiService.manage2FA({}))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.navigate([""]);
        },
        error: () => {
          
        }
      });
  }

  public onSubmit(model: LoginModel): void {
    this.withLoading(this.identityApiService.login(model))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.notifySuccess("Signed in successfully.");
        },
        error: error => this.handleError(error, "Unable to sign in."),
      });
  }
}
