import { FormControl, FormGroup, ValidatorFn, AbstractControlOptions } from "@angular/forms";

/**
 * Strongly-typed FormGroup for Angular forms.
 * Provides type-safe access to controls and values, plus common utility methods.
 */
export class ModelFormGroup<T> extends FormGroup<{
  [K in keyof T]: FormControl<T[K] | null>;
}> {
  constructor(
    controls: { [K in keyof T]: FormControl<T[K] | null> },
    validatorOrOpts?: ValidatorFn | ValidatorFn[] | AbstractControlOptions | null
  ) {
    super(controls, validatorOrOpts);
  }

  public get getvalue(): T {
    return super.getRawValue() as T;
  }

  public override markAllAsTouched(): void {
    Object.values(this.controls).forEach(control => control.markAsTouched());
  }
}