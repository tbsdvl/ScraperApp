import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  otpauthUri!: string;
  title = 'Listopotamus';

  constructor() {
    this.encode();
  }

  public encode(): void {
    this.otpauthUri = `otpauth://totp/listopotamus:${"your-email"}?secret=${"your-secret"}&issuer=listopotamus&digits=6&period=30`;
  }
}
