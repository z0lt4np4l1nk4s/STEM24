import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  API_URL: string = environment.API_URL;
  private access = 'access-token';
  private expiration = 'expiration';
  private userId = 'user_id';

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: any): Observable<any> {
    return this.http.post<any>(`auth/login`, credentials);
  }

  logout(): void {
    localStorage.removeItem(this.access);
    localStorage.removeItem(this.expiration);
    localStorage.removeItem(this.userId);

    this.router.navigate(['/login']);
  }

  isTokenValid(): boolean {
    const token = this.getToken();
    if (!token) {
      return false;
    }
    const tokenExpiration = this.getTokenExpiration();
    const now = new Date().getTime();
    return tokenExpiration > now;
  }

  isLoggedIn(): boolean {
    if(this.isTokenValid()) {
      return true;
    }
    this.logout();
    return false;
  }

  getToken(): string | null {
    return localStorage.getItem(this.access);
  }
  getTokenExpiration(): number {
    const exp = localStorage.getItem(this.expiration);
    if(!exp) return 0
    return Date.parse(exp);
  }

  saveTokens(tokens: any): void {
    localStorage.setItem(this.access, tokens.token);
    localStorage.setItem(this.expiration, tokens.expiration)
    localStorage.setItem(this.userId, tokens.user_id)
  }

  decodeToken(token: string): any {
    return jwtDecode(token);
  }
}
