import { Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { LoginComponent } from '../components/login/login.component';
import { RegisterComponent } from '../components/register/register.component';
import { LogoutComponent } from '../components/logout/logout.component';
import { TwoFaSetupComponent } from '../components/two-factor-auth/two-fa-setup/two-fa-setup.component';
import { TwoFaVerifyComponent } from '../components/two-factor-auth/two-fa-verify/two-fa-verify.component';

export const AUTH_ROUTES: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent, canActivate: [AuthGuard] },
  {
    path: 'manage/2fa/setup',
    component: TwoFaSetupComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'manage/2fa/verify',
    component: TwoFaVerifyComponent,
    canActivate: [AuthGuard],
  },
];
