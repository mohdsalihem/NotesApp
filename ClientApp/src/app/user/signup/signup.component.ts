import { Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { UsernameTaken } from 'src/app/validators/username-taken';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  userService = inject(UserService);
  router = inject(Router);
  usernameTaken = inject(UsernameTaken);

  firstName = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(50),
  ]);
  lastName = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(50),
  ]);
  username = new FormControl(
    '',
    [Validators.required, Validators.minLength(3), Validators.maxLength(50)],
    [this.usernameTaken.validate],
  );
  password = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(50),
  ]);

  signupForm = new FormGroup({
    firstName: this.firstName,
    lastName: this.lastName,
    username: this.username,
    password: this.password,
  });

  error = '';

  ngOnInit(): void {
    if (this.userService.currentUser$.value) {
      this.router.navigate(['/']);
    }
  }

  signup() {
    this.error = '';
    const user: User = {
      firstName: this.firstName.value!,
      lastName: this.lastName.value!,
      username: this.username.value!,
      password: this.password.value!,
    };
    this.userService.signup(user).subscribe({
      next: (success) => {
        if (success) {
          this.router.navigate(['/note']);
        }
      },
      error: () => {
        this.error = 'Something unexpected occured';
      },
    });
  }
}
