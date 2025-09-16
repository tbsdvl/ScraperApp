import { Component, OnInit } from '@angular/core';
import { BaseIdentityComponent } from '../base-identity/base-identity.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: false,
})
export class LoginComponent extends BaseIdentityComponent implements OnInit {
  constructor() {
    super();
  }

  public ngOnInit(): void {}
}
