import { Injectable } from '@angular/core';
import { environment } from '../../../environment';

export interface AccessTokenResponse {
  tokenType: string; // e.g. 'Bearer'
  accessToken: string; // opaque, not JWT
  expiresIn: number; // seconds
  refreshToken: string;
}

interface StoredAuth {
  token: AccessTokenResponse;
  acquiredAt: number; // epoch ms
  email: string;
}

@Injectable({ providedIn: 'root' })
export class TokenService {
  private key = environment.tokenStorageKey;

  get auth(): StoredAuth | null {
    const raw = localStorage.getItem(this.key);
    return raw ? (JSON.parse(raw) as StoredAuth) : null;
  }

  set auth(value: StoredAuth | null) {
    if (!value) localStorage.removeItem(this.key);
    else localStorage.setItem(this.key, JSON.stringify(value));
  }

  clear() {
    this.auth = null;
  }

  get accessToken(): string | null {
    return this.auth?.token.accessToken ?? null;
  }

  get secondsToExpiry(): number {
    const a = this.auth;
    if (!a) return 0;
    const elapsed = (Date.now() - a.acquiredAt) / 1000;
    return Math.max(0, a.token.expiresIn - elapsed);
  }

  needsRefresh(thresholdSec = 60): boolean {
    return this.secondsToExpiry <= thresholdSec;
  }
}
