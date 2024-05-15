import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth/auth-service.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const errorHandler = inject(ErrorHandlerService);

  let token = authService.getToken();
  if (token) {
    // check if the token is valid
    const isTokenValid = authService.isTokenValid();

    if (!isTokenValid) {
      authService.logout();
    }
  }

  let url = `${environment.API_URL}${req.url}`;

  const apiReq = req.clone({
    url,
    // withCredentials: true,
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });

  return next(apiReq);
};
