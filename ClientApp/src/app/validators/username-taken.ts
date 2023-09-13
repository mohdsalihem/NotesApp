import { Injectable, inject } from '@angular/core';
import {
  AbstractControl,
  AsyncValidator,
  ValidationErrors,
} from '@angular/forms';
import { Observable, of, delay, firstValueFrom } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root',
})
export class UsernameTaken implements AsyncValidator {
  userService = inject(UserService);
  validate = (
    control: AbstractControl,
  ): Observable<ValidationErrors | null> => {
    const isUsernameExist$ = of(control.value).pipe(
      delay(1000),
      switchMap((usename) =>
        firstValueFrom(this.userService.isUsernameExist(usename)).then(
          (response) => {
            return response && response.length ? { usernameTaken: true } : null;
          },
        ),
      ),
    );
    return isUsernameExist$;
  };
}
