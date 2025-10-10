import { Component } from '@angular/core';
import { BaseComponent } from '../../core/components/base/base.component';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
})
export class HeaderComponent extends BaseComponent { 

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