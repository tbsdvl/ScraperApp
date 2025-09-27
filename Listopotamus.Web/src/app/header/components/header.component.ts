import { Component } from '@angular/core';
import { BaseIdentityComponent } from '../../core/auth/components/base-identity/base-identity.component';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
})
export class HeaderComponent extends BaseIdentityComponent {
  public isLoggedIn: boolean = false;
  
  public override ngOnInit(): void {
    this.withLoading(this.identityApiService.getManageInfo())
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: (result) => {
          if (result.email) {
            this.isLoggedIn = true;
          }
        }
      });
  }
}