import { Component } from '@angular/core';
import { Router } from '@angular/router';
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

  public logout(): void {
    this.withLoading(this.identityApiService.logout())
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.isLoggedIn = false;
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error('Logout failed:', error);
          // Even if there's an error, we should update the UI state
          this.isLoggedIn = false;
          this.router.navigate(['/']);
        }
      });
  }
}