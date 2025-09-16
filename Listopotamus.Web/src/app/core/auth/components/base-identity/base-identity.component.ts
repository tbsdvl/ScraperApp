import { inject } from '@angular/core';
import { BaseComponent } from '../../../components/base/base.component';
import { IdentityApiService } from '../../services/identity-api.service';

export abstract class BaseIdentityComponent extends BaseComponent {
  protected identityApiService = inject(IdentityApiService);
}
