import { Component, OnInit, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';
import { TokenService } from '../services/token.service';
import { takeUntil } from 'rxjs';
import { destroyNotifier } from '../helpers/destroyNotifier';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: [],
  standalone: true,
  imports: [RouterLink, CommonModule],
})
export class NavComponent implements OnInit {
  authService = inject(AuthService);
  tokenService = inject(TokenService);
  router = inject(Router);
  destroy$ = destroyNotifier();

  get isSignedIn() {
    return !!this.authService.currentUser();
  }

  ngOnInit(): void {}

  logout() {
    this.tokenService.revoke().pipe(takeUntil(this.destroy$)).subscribe();
    this.authService.logout();
    this.router.navigate(['user/login']);
  }
}
