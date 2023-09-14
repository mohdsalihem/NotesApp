import { Component, OnInit, inject } from '@angular/core';
import {
  Validators,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { InputComponent } from '../../shared/input/input.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [NgIf, ReactiveFormsModule, InputComponent],
})
export class LoginComponent implements OnInit {
  userService = inject(UserService);
  router = inject(Router);

  loginForm = new FormGroup({
    username: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
    }),
  });

  errorMessage = '';

  ngOnInit(): void {
    if (this.userService.currentUser$.value) {
      this.router.navigate(['/']);
    }
  }

  login() {
    this.errorMessage = '';
    this.userService
      .login(
        this.loginForm.controls.username.value,
        this.loginForm.controls.password.value,
      )
      .subscribe({
        next: (isSuccess) => {
          if (isSuccess) {
            this.router.navigate(['/note']);
          }
        },
        error: () => {
          this.errorMessage = 'Invalid username or password';
        },
      });
  }

  signup() {
    this.router.navigate(['user/signup']);
  }
}
