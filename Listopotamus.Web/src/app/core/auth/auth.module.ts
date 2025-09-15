import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { QRCodeModule } from 'angularx-qrcode';

import { AUTH_ROUTES } from './auth.routes';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { TwoFaSetupComponent } from './components/twofa-setup/twofa-setup.component';
import { TwoFaVerifyComponent } from './components/twofa-verify/twofa-verify.component';
import { LoginMenuComponent } from './components/login-menu/login-menu.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CredentialsInterceptor } from './interceptors/credentials.interceptor';
import { AuthStateService } from './services/auth-state.service';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    TwoFaSetupComponent,
    TwoFaVerifyComponent,
    LoginMenuComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(AUTH_ROUTES),
    QRCodeModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CredentialsInterceptor,
      multi: true,
    },
    AuthStateService,
  ],
  exports: [LoginMenuComponent],
})
export class AuthModule {}
