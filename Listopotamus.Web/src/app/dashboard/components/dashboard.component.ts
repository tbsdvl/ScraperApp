import { Component } from "@angular/core";
import { BaseComponent } from "../../core/components/base/base.component";

@Component({
  selector: "app-dashboard",
  templateUrl: "dashboard.component.html",
  standalone: false,
})
export class DashboardComponent extends BaseComponent {
  constructor() {
    super();
  }
}