import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { TwoFaSetupComponent } from './components/twofa-setup/twofa-setup.component';
import { TwoFaVerifyComponent } from './components/twofa-verify/twofa-verify.component';
import { AuthGuard } from '../guards/auth.guard';

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
