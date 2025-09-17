import { NgModule } from "@angular/core";
import { LandingPageComponent } from "./components/landing-page/landing-page.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { AuthModule } from "./auth/auth.module";

@NgModule({
  declarations: [
    LandingPageComponent,
    DashboardComponent,
  ],
  imports: [
    AuthModule
  ],
  exports: [
    LandingPageComponent,
    DashboardComponent,
  ]
})
export class CoreModule {}