import { Component, OnInit } from '@angular/core';
import { BaseIdentityComponent } from '../base-identity/base-identity.component';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  standalone: false,
})
export class LogoutComponent extends BaseIdentityComponent implements OnInit {
  constructor() {
    super();
  }

  public ngOnInit(): void {}
}
