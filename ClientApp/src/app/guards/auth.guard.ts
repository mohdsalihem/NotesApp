import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  router = inject(Router);
  userService = inject(UserService);

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.userService.currentUser$.value;

    if (currentUser) {
      // Logged in
      return true;
    }

    this.router.navigate(['user/login']);
    return false;
  }
}
