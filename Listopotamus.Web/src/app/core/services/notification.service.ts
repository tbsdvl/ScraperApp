import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class NotificationService {
  public showSuccess(message: string): void {
    console.log(message);
  }

  public showInfo(message: string): void {
    console.info(message);
  }

  public showWarning(message: string): void {
    console.warn(message);
  }

  public showError(message: string, error?: unknown): void {
    console.error(message, error);
  }
}
