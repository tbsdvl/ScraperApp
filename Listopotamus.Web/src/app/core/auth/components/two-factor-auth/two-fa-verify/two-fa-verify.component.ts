import { Component, inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { finalize } from "rxjs/operators";

import { TwoFaCommand } from "../../../commands/two-fa.command";
import { Manage2FAInfoModel } from "../../../models/manage-2fa-info.model";
import { BaseComponent } from "../../../../components/base/base.component";

@Component({
  selector: "app-two-fa-verify",
  templateUrl: "./two-fa-verify.component.html",
  standalone: false,
})
export class TwoFaVerifyComponent extends BaseComponent {
  private readonly formBuilder = inject(FormBuilder);

  public verificationForm = this.formBuilder.group({
    verificationCode: ["", [Validators.required]],
    recoveryCode: [""],
  });

  public useRecoveryCode = false;
  public isSubmitting = false;
  public loadError: string | null = null;
  public submitError: string | null = null;
  public email: string | null = null;
  public isTwoFactorEnabled = false;

  public override ngOnInit(): void {
    super.ngOnInit();
    this.loadAccountInfo();
  }

  public toggleRecoveryCode(): void {
    this.useRecoveryCode = !this.useRecoveryCode;
    const verificationControl = this.verificationForm.get("verificationCode");
    const recoveryControl = this.verificationForm.get("recoveryCode");

    if (this.useRecoveryCode) {
      verificationControl?.clearValidators();
      verificationControl?.setValue("");
      recoveryControl?.setValidators([Validators.required]);
    } else {
      recoveryControl?.clearValidators();
      recoveryControl?.setValue("");
      verificationControl?.setValidators([Validators.required]);
    }

    verificationControl?.updateValueAndValidity();
    recoveryControl?.updateValueAndValidity();
    this.submitError = null;
  }

  public submitVerification(): void {
    this.submitError = null;
    const control = this.useRecoveryCode
      ? this.verificationForm.get("recoveryCode")
      : this.verificationForm.get("verificationCode");

    if (!control) {
      return;
    }

    this.verificationForm.markAllAsTouched();

    if (control.invalid) {
      return;
    }

    const rawCode = (control.value ?? "").toString();
    const code = rawCode.replace(/\s+/g, "");

    if (!code) {
      control.setErrors({ required: true });
      return;
    }

    const command: TwoFaCommand = {
      action: "Enable",
      twoFactorCode: code,
    };

    this.isSubmitting = true;

    this.identityApiService
      .twoFa(command)
      .pipe(
        this.takeUntilDestroyed(),
        finalize(() => {
          this.isSubmitting = false;
        })
      )
      .subscribe({
        next: () => {
          this.notifySuccess("Two-factor authentication verified successfully.");
          this.goBackToAccount();
        },
        error: (error) => {
          this.submitError = "The code was not accepted. Please try again.";
          this.handleError(error, this.submitError);
        },
      });
  }

  public goBackToAccount(): void {
    this.navigate(["/manage/2fa/setup"]);
  }

  private loadAccountInfo(): void {
    this.loadError = null;
    this.withLoading(this.identityApiService.manage2FA({}))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: (info: Manage2FAInfoModel) => {
          this.email = info.email;
          this.isTwoFactorEnabled = info.isTwoFactorEnabled;
        },
        error: (error) => {
          this.loadError = "Unable to load verification details.";
          this.handleError(error, this.loadError);
        },
      });
  }
}