import { Component, OnInit, inject } from '@angular/core';
import {
  Validators,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { InputComponent } from '../../shared/input/input.component';
import { CommonModule } from '@angular/common';
import { takeUntil } from 'rxjs';
import { destroyNotifier } from 'src/app/helpers/destroyNotifier';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, InputComponent],
})
export class LoginComponent implements OnInit {
  authService = inject(AuthService);
  router = inject(Router);
  destroy$ = destroyNotifier();

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
    if (this.authService.currentUser()) {
      this.router.navigate(['/']);
    }
  }

  login() {
    this.errorMessage = '';
    this.authService
      .login(
        this.loginForm.controls.username.value,
        this.loginForm.controls.password.value,
      )
      .pipe(takeUntil(this.destroy$))
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
