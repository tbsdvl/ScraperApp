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
    this.otpauthUri = "otpauth://totp/listopotamus:test@email.com?secret=2AWR4A3A2ATHTFPKZB7FFNA4LDFGYI3C&issuer=listopotamus&digits=6&period=30";
    console.log(this.otpauthUri);
  }
}
