export interface ManageInfoModel {
  email: string;
  isEmailConfirmed: boolean;
  isTwoFactorEnabled: boolean;
  authenticatorKey?: string;
  recoveryCodesLeft?: number;
}
