export interface Manage2FAInfoModel {
  email: string;
  sharedKey: string,
  recoveryCodesLeft: number,
  recoveryCodes: string[],
  isTwoFactorEnabled: boolean,
  isMachineRemembered: boolean,
}
