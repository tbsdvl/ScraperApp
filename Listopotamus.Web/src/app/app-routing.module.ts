import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LandingPageComponent } from "./core/components/landing-page/landing-page.component";
import { DashboardComponent } from "./core/components/dashboard/dashboard.component";
import { AuthGuard } from "./core/auth/guards/auth.guard";

const routes: Routes = [
  {
    path: "",
    children: [
      {
        path: "",
        component: LandingPageComponent,
      },
      {
        path: "dashboard",
        component: DashboardComponent,
        canActivate: [AuthGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
