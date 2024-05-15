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

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: any): Observable<any> {
    return this.http.post<any>(`login`, credentials);
  }

  logout(): void {
    localStorage.removeItem(this.access);

    this.router.navigate(['/login']);
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

  saveTokens(tokens: any): void {
    localStorage.setItem(this.access, tokens.access_token);
  }

  decodeToken(token: string): any {
    return jwtDecode(token);
  }

  
}
