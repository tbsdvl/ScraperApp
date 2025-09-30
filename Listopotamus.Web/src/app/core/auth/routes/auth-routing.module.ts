import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "../guards/auth.guard";
import { LoginComponent } from "../components/login/login.component";
import { RegistrationComponent } from "../components/register/registration.component";
import { LogoutComponent } from "../components/logout/logout.component";
import { TwoFaSetupComponent } from "../components/two-factor-auth/two-fa-setup/two-fa-setup.component";
import { TwoFaVerifyComponent } from "../components/two-factor-auth/two-fa-verify/two-fa-verify.component";
import { NgModule } from "@angular/core";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "registration", component: RegistrationComponent },
  { path: "logout", component: LogoutComponent, canActivate: [AuthGuard] },
  {
    path: "manage/2fa/setup",
    component: TwoFaSetupComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "manage/2fa/verify",
    component: TwoFaVerifyComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {};