import { Component } from '@angular/core';
import { BaseIdentityComponent } from '../../core/auth/components/base-identity/base-identity.component';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
})
export class HeaderComponent extends BaseIdentityComponent { 

  constructor() {
    super();    
  }

  public logout(): void {
    this.identityApiService.logout()
      .pipe(this.takeUntilDestroyed())
      .subscribe({
        next: () => {
          this.isLoggedIn = false;
          this.navigate(["/login"]);
        },
        error: (error) => {
          console.error('Logout failed:', error);
          this.isLoggedIn = false;
        }
      });
  }
}