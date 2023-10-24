import { Injectable, inject } from '@angular/core';
import {
  AbstractControl,
  AsyncValidator,
  ValidationErrors,
} from '@angular/forms';
import { Observable, of, delay, switchMap, map } from 'rxjs';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root',
})
export class UsernameTaken implements AsyncValidator {
  userService = inject(UserService);
  validate = (
    control: AbstractControl,
  ): Observable<ValidationErrors | null> => {
    return of(control.value).pipe(
      delay(500),
      switchMap((usename) =>
        this.userService
          .isUsernameExist(usename)
          .pipe(map((result) => (result ? { usernameTaken: true } : null))),
      ),
    );
  };
}
