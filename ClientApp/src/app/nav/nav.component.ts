import { Component, OnInit, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../services/user.service';
import { NgIf } from '@angular/common';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styles: [],
    standalone: true,
    imports: [RouterLink, NgIf],
})
export class NavComponent implements OnInit {
  userService = inject(UserService);
  router = inject(Router);
  visibleLogout = false;

  ngOnInit(): void {
    this.userService.currentUser$.subscribe((user) => {
      if (user) {
        this.visibleLogout = true;
      } else {
        this.visibleLogout = false;
      }
    });
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['user/login']);
  }

  login() {
    this.router.navigate(['user/login']);
  }
}
