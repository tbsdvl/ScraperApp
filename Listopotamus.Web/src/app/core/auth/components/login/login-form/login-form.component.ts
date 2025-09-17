import { Component, EventEmitter, Output } from "@angular/core";
import { Validators } from "@angular/forms";

import { LoginModel } from "../../../models/login.model";
import { BaseFormComponent } from "../../../../components/base-form/base-form.component";
import { ModelFormGroup } from "../../../../models/model-form-group.model";

@Component({
  selector: "app-login-form",
  templateUrl: "./login-form.component.html",
  standalone: false,
})
export class LoginFormComponent extends BaseFormComponent<LoginModel> {
  @Output() public formSubmit = new EventEmitter<LoginModel>();

  protected override buildForm(): ModelFormGroup<LoginModel> {
    return this.formBuilder.group({
      email: ["", [Validators.required]],
      password: ["", [Validators.required]],
      twoFactorCode: [null],
      twoFactorRecoveryCode: [null],
    }) as ModelFormGroup<LoginModel>;
  }

  protected override onSubmit(value: LoginModel): void {
    if (this.form.valid) {
      this.formSubmit.emit(value);
    }
  }
}
