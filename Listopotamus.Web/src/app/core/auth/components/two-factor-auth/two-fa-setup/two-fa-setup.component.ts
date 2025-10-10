import { Component, inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { finalize } from "rxjs/operators";

import { TwoFaCommand } from "../../../commands/two-fa.command";
import { Manage2FAInfoModel } from "../../../models/manage-2fa-info.model";
import { BaseIdentityComponent } from "../../base-identity/base-identity.component";

@Component({
  selector: "app-two-fa-setup",
  templateUrl: "./two-fa-setup.component.html",
  standalone: false,
})
export class TwoFaSetupComponent extends BaseIdentityComponent {
  private readonly formBuilder = inject(FormBuilder);

  public info: Manage2FAInfoModel | null = null;
  public sharedKey = "";
  public otpauthUri = "";
  public recoveryCodes: string[] = [];
  public isTwoFactorEnabled = false;
  public recoveryCodesLeft = 0;

  public actionError: string | null = null;
  public loadError: string | null = null;
  public isActionLoading = false;

  public enableForm = this.formBuilder.group({
    code: ["", [Validators.required]],
  });

  public override ngOnInit(): void {
    super.ngOnInit();
    this.loadTwoFactorInfo();
  }

  public enableTwoFactor(): void {
    if (this.enableForm.invalid) {
      this.enableForm.markAllAsTouched();
      return;
    }

    const codeControl = this.enableForm.get("code");
    const code = (codeControl?.value ?? "").toString().replace(/\s+/g, "");

    if (!code) {
      codeControl?.setErrors({ required: true });
      return;
    }

    this.executeAction(
      { action: "Enable", twoFactorCode: code },
      "Two-factor authentication has been enabled.",
      () => {},
      () => {
        this.navigate(["/manage/2fa/verify"]);
      }
    );
  }

  public disableTwoFactor(): void {
    this.executeAction(
      { action: "Disable" },
      "Two-factor authentication has been disabled."
    );
  }

  public generateRecoveryCodes(): void {
    this.executeAction(
      { action: "GenerateRecoveryCodes" },
      "New recovery codes have been generated."
    );
  }

  public resetAuthenticator(): void {
    this.executeAction(
      { action: "ResetAuthenticator" },
      "The authenticator app has been reset. Please scan the new QR code and verify it.",
      () => {
        this.enableForm.reset();
      }
    );
  }

  private loadTwoFactorInfo(): void {
    this.loadError = null;
    this.withLoading(this.identityApiService.manage2FA({}))
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: (info) => {
          this.info = info;
          this.sharedKey = info.sharedKey ?? "";
          this.otpauthUri = `otpauth://totp/listopotamus:${info.email}?secret=${info.sharedKey}&issuer=listopotamus&digits=6&period=30`;
          this.recoveryCodes = info.recoveryCodes ?? [];
          this.isTwoFactorEnabled = info.isTwoFactorEnabled;
          this.recoveryCodesLeft = info.recoveryCodesLeft ?? this.recoveryCodes.length;
        },
        error: (error) => {
          this.loadError = "Unable to load two-factor authentication details.";
          this.handleError(error, this.loadError);
        },
      });
  }

  private executeAction(
    command: TwoFaCommand,
    successMessage: string,
    onSuccess?: () => void,
    onError?: () => void,
  ): void {
    this.actionError = null;
    this.isActionLoading = true;

    this.identityApiService
      .twoFa(command)
      .pipe(
        this.takeUntilDestroyed(),
        finalize(() => {
          this.isActionLoading = false;
        })
      )
      .subscribe({
        next: () => {
          onSuccess?.();
          this.notifySuccess(successMessage);
          this.loadTwoFactorInfo();
        },
        error: (error) => {
          onError?.();
          this.actionError = "We couldn't process your request. Please try again.";
          this.handleError(error, this.actionError);
        },
      });
  }
}