import { Component } from '@angular/core';
import { BaseIdentityComponent } from '../../base-identity/base-identity.component';

@Component({
  selector: 'app-two-fa-verify',
  templateUrl: './two-fa-verify.component.html',
  standalone: false,
})
export class TwoFaVerifyComponent extends BaseIdentityComponent {
  constructor() {
    super();
  }
}
