import { Component, OnInit, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { NgIf } from '@angular/common';
import { AuthService } from '../services/auth.service';
import { TokenService } from '../services/token.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: [],
  standalone: true,
  imports: [RouterLink, NgIf],
})
export class NavComponent implements OnInit {
  authService = inject(AuthService);
  tokenService = inject(TokenService);
  router = inject(Router);
  visibleLogout = false;

  ngOnInit(): void {
    this.authService.currentUser$.subscribe((user) => {
      if (user) {
        this.visibleLogout = true;
      } else {
        this.visibleLogout = false;
      }
    });
  }

  logout() {
    this.authService.logout();
    this.tokenService.revoke().subscribe();
    this.router.navigate(['user/login']);
  }

  login() {
    this.router.navigate(['user/login']);
  }
}
