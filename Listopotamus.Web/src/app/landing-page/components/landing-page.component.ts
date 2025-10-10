import { Component } from "@angular/core";
import { BaseComponent } from "../../core/components/base/base.component";

@Component({
  selector: "app-landing-page",
  templateUrl: "./landing-page.component.html",
  standalone: false,
})
export class LandingPageComponent extends BaseComponent {
  public isEmailConfirmed: boolean = false;

  constructor() {
    super();
  }
}