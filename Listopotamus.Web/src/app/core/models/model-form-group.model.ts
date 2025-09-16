import { FormGroup } from '@angular/forms';

export interface ModelFormGroup<T> extends Omit<FormGroup, 'setValue'> {
  value: T;
  getRawValue(): T;
  patchValue(
    value: Partial<T>,
    options?: { onlySelf?: boolean; emitEvent?: boolean }
  ): void;
  setValue(
    value: T,
    options?: { onlySelf?: boolean; emitEvent?: boolean }
  ): void;
  reset(
    value?: Partial<T>,
    options?: { onlySelf?: boolean; emitEvent?: boolean }
  ): void;
}