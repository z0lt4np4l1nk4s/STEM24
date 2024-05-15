import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { jwtDecode } from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  API_URL: string = environment.API_URL;
  private access = 'access-token';
  private refresh = 'refresh-token';

  constructor(private http: HttpClient) {}

  login(credentials: any): Observable<any> {
    return this.http.post<any>(`login`, credentials);
  }

  logout(): void {
    localStorage.removeItem(this.access);
    localStorage.removeItem(this.refresh);
  }

  isTokenValid(): boolean {
    const token = this.getToken();
    if (!token) {
      return false;
    }
    const tokenExpiration = this.decodeToken(token).exp * 1000;
    const now = new Date().getTime();
    return tokenExpiration > now;
  }
  isRefreshTokenValid(): boolean {
    const refreshToken = this.getRefreshToken();
    if (!refreshToken) {
      return false;
    }
    const refreshTokenExpiration = this.decodeToken(refreshToken).exp * 1000;
    const now = new Date().getTime();
    return refreshTokenExpiration > now;
  }

  isLoggedIn(): boolean {
    if(this.isTokenValid()) {
      return true;
    }
    if(this.isRefreshTokenValid()) {
      this.refreshToken().subscribe(
        (response) => {
          this.saveTokens(response);
          return true;
        },
        (error) => {
          this.logout();
          return false;
        }
      );
    }
    this.logout();
    return false;
  }

  getToken(): string | null {
    return localStorage.getItem(this.access);
  }

  getRefreshToken(): string | null {
    return localStorage.getItem(this.refresh);
  }

  saveTokens(tokens: any): void {
    localStorage.setItem(this.access, tokens.access_token);
    localStorage.setItem(this.refresh, tokens.refresh_token);
  }

  refreshToken(): Observable<any> {
    const refreshToken = this.getRefreshToken();
    return this.http.post<any>(`refresh-token`, { refreshToken });
  }

  decodeToken(token: string): any {
    return jwtDecode(token);
  }

  
}
