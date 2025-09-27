import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LandingPageComponent } from "./landing-page/components/landing-page.component";
import { AuthGuard } from "./core/auth/guards/auth.guard";
import { DashboardComponent } from "./dashboard/components/dashboard.component";

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
