import { Component, OnInit } from '@angular/core';
import { BaseIdentityComponent } from '../../base-identity/base-identity.component';

@Component({
  selector: 'app-two-fa-setup',
  templateUrl: './two-fa-setup.component.html',
  standalone: false,
})
export class TwoFaSetupComponent extends BaseIdentityComponent implements OnInit {
  constructor() {
    super();
  }

  public ngOnInit(): void {}
}
