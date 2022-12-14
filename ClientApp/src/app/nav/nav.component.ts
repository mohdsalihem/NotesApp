import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: [],
})
export class NavComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {}
  visibleLogout = false;
  ngOnInit(): void {
    this.userService.currentUser.subscribe((user) => {
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
