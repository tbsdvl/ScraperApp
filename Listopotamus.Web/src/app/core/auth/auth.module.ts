import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { LoginComponent } from "./components/login/login.component";
import { RegistrationComponent } from "./components/register/registration.component";
import { LogoutComponent } from "./components/logout/logout.component";
import { TwoFaSetupComponent } from "./components/two-factor-auth/two-fa-setup/two-fa-setup.component";
import { TwoFaVerifyComponent } from "./components/two-factor-auth/two-fa-verify/two-fa-verify.component";

import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { CredentialsInterceptor } from "./interceptors/credentials.interceptor";
import { AuthStateService } from "./services/auth-state.service";
import { QRCodeComponent } from "angularx-qrcode";
import { LoginFormComponent } from "./components/login/login-form/login-form.component";
import { AuthRoutingModule } from "./routes/auth-routing.module";
import { RegistrationFormComponent } from "./components/register/registration-form/registration-form.component";

@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    LogoutComponent,
    TwoFaSetupComponent,
    TwoFaVerifyComponent,
    LoginFormComponent,
    RegistrationFormComponent
  ],
  imports: [
    QRCodeComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AuthRoutingModule,
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
