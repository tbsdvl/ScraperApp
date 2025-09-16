import { Component, OnInit } from '@angular/core';
import { BaseIdentityComponent } from '../base-identity/base-identity.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  standalone: false,
})
export class RegisterComponent extends BaseIdentityComponent implements OnInit {
  constructor() {
    super();
  }

  public ngOnInit(): void {}
}
