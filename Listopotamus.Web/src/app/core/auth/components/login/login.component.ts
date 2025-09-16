import { Component } from '@angular/core';
import { BaseIdentityComponent } from '../base-identity/base-identity.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: false,
})
export class LoginComponent extends BaseIdentityComponent {
  constructor() {
    super();
  }
}
