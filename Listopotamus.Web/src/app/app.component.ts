import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  otpauthUri!: string;
  title = 'ScraperApp';

  constructor() {
    this.encode();
  }

  public encode(): void {
    "otpauth://totp/listopotamus:test@email.com?secret=MOOLKIWBNNMUTWSC62DOF6L7O37LE2YF&issuer=listopotamus&digits=6&period=30"
    this.otpauthUri = "otpauth://totp/listopotamus:test@email.com?secret=MOOLKIWBNNMUTWSC62DOF6L7O37LE2YF&issuer=listopotamus&digits=6&period=30";
    console.log(this.otpauthUri);
  }
}
