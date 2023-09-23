import { Component, OnDestroy, OnInit, computed, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';
import { TokenService } from '../services/token.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: [],
  standalone: true,
  imports: [RouterLink, CommonModule],
})
export class NavComponent implements OnInit, OnDestroy {
  authService = inject(AuthService);
  tokenService = inject(TokenService);
  router = inject(Router);
  destroy$ = new Subject<void>();

  get isSignedIn() {
    return !!this.authService.currentUser();
  }

  ngOnInit(): void {}

  logout() {
    this.authService.logout();
    this.tokenService.revoke().pipe(takeUntil(this.destroy$)).subscribe();
    this.router.navigate(['user/login']);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
