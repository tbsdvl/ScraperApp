import { Component } from "@angular/core";
import { BaseComponent } from "../base/base.component";
import { IdentityApiService } from "../../auth/services/identity-api.service";

@Component({
  selector: "app-landing-page",
  template: "",
  standalone: false,
})
export class LandingPageComponent extends BaseComponent {

  constructor(
    private authService: IdentityApiService,
  ) {
    super();

    // determine whether or not the user is authenticated
    // the identity API service exposes functions to check if a user is authenticated
    // if the user is authenticated, then navigate to the dashboard
    // otherwise, navigate to the login page.
  }

  public override ngOnInit(): void {
    this.authService.getManageInfo()
      .subscribe({
        next: (result) => {
          if (result.email) {
            this.navigate(["dashboard"]);
          } else {
            this.navigate(["login"]);
          }
        },
        error: () => {
          this.navigate(["login"]);
        }
      })
  }
}