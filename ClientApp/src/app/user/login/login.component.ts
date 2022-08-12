import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  username = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(50),
  ]);
  password = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(50),
  ]);
  loginForm = new FormGroup({
    username: this.username,
    password: this.password,
  });

  error = '';
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    if (this.userService.currentUser.value) {
      this.router.navigate(['/']);
    }
  }

  login() {
    this.error = '';
    this.userService
      .login(this.username.value!, this.password.value!)
      .subscribe({
        next: (success) => {
          if (success) {
            this.router.navigate(['/note']);
          }
        },
        error: (err) => {
          this.error = 'Invalid username or password';
        },
      });
  }

  signup() {
    this.router.navigate(['user/signup']);
  }
}
