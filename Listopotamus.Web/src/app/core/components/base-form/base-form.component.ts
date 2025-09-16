import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, ValidationErrors } from '@angular/forms';

import { BaseComponent } from '../base/base.component';
import { ModelFormGroup } from '../../models/model-form-group.model';

@Component({
  selector: 'app-base-form',
  template: '',
})
export abstract class BaseFormComponent<TValue>
  extends BaseComponent
  implements OnInit
{
  protected readonly formBuilder = inject(FormBuilder);

  public form!: ModelFormGroup<TValue>;
  public submitted = false;

  public override ngOnInit(): void {
    super.ngOnInit();
    this.form = this.buildForm();
    this.afterFormInit();
  }

  protected abstract buildForm(): ModelFormGroup<TValue>;

  protected afterFormInit(): void {}

  public submit(event?: Event): void {
    event?.preventDefault();

    this.submitted = true;
    this.markAllControlsTouched();

    if (this.form.valid) {
      this.onSubmit(this.getValue());
    } else {
      this.onInvalidSubmit();
    }
  }

  protected abstract onSubmit(value: TValue): void;

  protected onInvalidSubmit(): void {
    const message = this.getInvalidSubmitMessage();
    if (message) {
      this.notifyWarning(message);
    }
  }

  protected getInvalidSubmitMessage(): string | null {
    return 'Please correct the errors in the form before continuing.';
  }

  protected getValue(): TValue {
    return this.form.getRawValue() as TValue;
  }

  protected patchFormValue(
    value: Partial<unknown>,
    options?: { emitEvent?: boolean }
  ): void {
    this.form.patchValue(value, options);
  }

  protected resetForm(): void {
    this.form.reset();
    this.submitted = false;
  }

  protected setControlValue(
    controlPath: string,
    value: unknown,
    options?: { emitEvent?: boolean }
  ): void {
    const control = this.getControl(controlPath);
    control?.setValue(value, options);
  }

  protected getControl(controlPath: string): AbstractControl | null {
    return this.form.get(controlPath);
  }

  protected hasError(controlPath: string, errorCode: string): boolean {
    const control = this.getControl(controlPath);
    return (
      !!control &&
      control.hasError(errorCode) &&
      this.shouldDisplayControlErrors(control)
    );
  }

  protected isControlInvalid(controlPath: string): boolean {
    const control = this.getControl(controlPath);
    return (
      !!control && control.invalid && this.shouldDisplayControlErrors(control)
    );
  }

  protected getControlErrors(controlPath: string): ValidationErrors | null {
    const control = this.getControl(controlPath);
    return control?.errors ?? null;
  }

  protected markAllControlsTouched(): void {
    this.form.markAllAsTouched();
  }

  protected markControlAsTouched(controlPath: string): void {
    const control = this.getControl(controlPath);
    control?.markAsTouched();
  }

  protected disableForm(options?: { emitEvent?: boolean }): void {
    this.form.disable(options);
  }

  protected enableForm(options?: { emitEvent?: boolean }): void {
    this.form.enable(options);
  }

  protected shouldDisplayControlErrors(control: AbstractControl): boolean {
    return control.dirty || control.touched || this.submitted;
  }
}
