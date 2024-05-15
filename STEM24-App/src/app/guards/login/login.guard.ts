import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth-service.service';
import { inject } from '@angular/core';

export const loginGuard: CanActivateFn = (_route, _state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  
  if (!authService.isLoggedIn()) {
    return true;
  } 
  else {
    router.navigate(['/events']);
    return false;
  }
};
