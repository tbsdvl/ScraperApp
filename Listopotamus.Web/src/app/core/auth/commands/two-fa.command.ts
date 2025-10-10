export interface TwoFaCommand {
  action:
    | "GenerateQrCode"
    | "Enable"
    | "Disable"
    | "GenerateRecoveryCodes"
    | "ResetAuthenticator";
  twoFactorCode?: string;
}
