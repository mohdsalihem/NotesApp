import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const AuthGuard: CanActivateFn = () => {
  const currentUser = inject(AuthService).currentUser();
  if (currentUser) {
    // Logged in
    return true;
  }

  inject(Router).navigate(['user/login']);
  return false;
};
