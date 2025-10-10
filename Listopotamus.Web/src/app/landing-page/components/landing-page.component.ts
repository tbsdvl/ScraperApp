import { Component } from "@angular/core";
import { BaseComponent } from "../../core/components/base/base.component";
import { IdentityApiService } from "../../core/auth/services/identity-api.service";

@Component({
  selector: "app-landing-page",
  template: "./landing-page.component.html",
  standalone: false,
})
export class LandingPageComponent extends BaseComponent {
  public isEmailConfirmed: boolean = false;

  constructor(
    private authService: IdentityApiService,
  ) {
    super();
  }

  public override ngOnInit(): void {
    this.authService.getManageInfo()
      .subscribe({
        next: (result) => {
          if (result.email && result.isEmailConfirmed) {
            this.isEmailConfirmed = true;
          } else if (result.email && !result.isEmailConfirmed) {
            
          }
        },
        error: () => {}
      })
  }
}