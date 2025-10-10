import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Validators } from "@angular/forms";

import { BaseFormComponent } from "../../../../components/base-form/base-form.component";
import { ModelFormGroup } from "../../../../models/model-form-group.model";
import { RegistrationModel } from "../../../models/registration.model";

@Component({
  selector: "app-registration-form",
  templateUrl: "./registration-form.component.html",
  standalone: false,
})
export class RegistrationFormComponent extends BaseFormComponent<RegistrationModel> {
  @Input() public showTwoFactorCodeControl!: boolean;
  @Output() public formSubmit = new EventEmitter<RegistrationModel>();

  protected override buildForm(): ModelFormGroup<RegistrationModel> {
    return this.formBuilder.group({
      email: ["", [Validators.required]],
      password: ["", [Validators.required]],
    }) as ModelFormGroup<RegistrationModel>;
  }

  protected override onSubmit(value: RegistrationModel): void {
    if (this.form.valid) {
      this.formSubmit.emit(value);
    }
  }
}
