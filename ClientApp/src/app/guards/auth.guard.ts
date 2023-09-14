import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';
import { UserService } from '../services/user.service';

export const AuthGuard: CanActivateFn = () => {
  const currentUser = inject(UserService).currentUser$.value;
  if (currentUser) {
    // Logged in
    return true;
  }

  inject(Router).navigate(['user/login']);
  return false;
};
