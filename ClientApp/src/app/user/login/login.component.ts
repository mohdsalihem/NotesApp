import { Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { InputComponent } from '../../shared/input/input.component';
import { NgIf } from '@angular/common';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    standalone: true,
    imports: [
        NgIf,
        ReactiveFormsModule,
        InputComponent,
    ],
})
export class LoginComponent implements OnInit {
  userService = inject(UserService);
  router = inject(Router);

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

  ngOnInit(): void {
    if (this.userService.currentUser$.value) {
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
        error: () => {
          this.error = 'Invalid username or password';
        },
      });
  }

  signup() {
    this.router.navigate(['user/signup']);
  }
}
