import { Component, OnInit, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UsernameTaken } from 'src/app/validators/username-taken';
import { InputComponent } from '../../shared/input/input.component';
import { CommonModule } from '@angular/common';
import { AuthService } from 'src/app/services/auth.service';
import { takeUntil } from 'rxjs';
import { destroyNotifier } from 'src/app/helpers/destroyNotifier';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, InputComponent],
})
export class SignupComponent implements OnInit {
  authService = inject(AuthService);
  router = inject(Router);
  usernameTaken = inject(UsernameTaken);
  destroy$ = destroyNotifier();

  signupForm = new FormGroup({
    firstName: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
    }),
    lastName: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
    }),
    username: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ],
      asyncValidators: this.usernameTaken.validate,
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

  signup() {
    this.errorMessage = '';
    const user = this.signupForm.value as User;
    this.authService
      .signup(user)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (success) => {
          if (success) {
            this.router.navigate(['/note']);
          }
        },
        error: () => {
          this.errorMessage = 'Something unexpected occured';
        },
      });
  }
}
