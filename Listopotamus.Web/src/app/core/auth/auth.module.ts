import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { TwoFaSetupComponent } from './components/two-factor-auth/two-fa-setup/two-fa-setup.component';
import { TwoFaVerifyComponent } from './components/two-factor-auth/two-fa-verify/two-fa-verify.component';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CredentialsInterceptor } from './interceptors/credentials.interceptor';
import { AuthStateService } from './services/auth-state.service';
import { AUTH_ROUTES } from './routes/auth.routes';
import { QRCodeComponent } from 'angularx-qrcode';
import { LoginFormComponent } from './components/login/login-form/login-form.component';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    TwoFaSetupComponent,
    TwoFaVerifyComponent,
    LoginFormComponent,
  ],
  imports: [
    QRCodeComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(AUTH_ROUTES),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CredentialsInterceptor,
      multi: true,
    },
    AuthStateService,
  ],
  exports: [LoginComponent],
})
export class AuthModule {}
