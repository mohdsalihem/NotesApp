import { inject } from '@angular/core';
import { HttpInterceptorFn, HttpStatusCode } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { UserService } from '../services/user.service';
import { environment } from 'src/environments/environment';

export const JwtInterceptor: HttpInterceptorFn = (req, next) => {
  const userService = inject(UserService);
  const currentUser = userService.currentUser$.value;
  const token = currentUser && currentUser.token ? currentUser.token : null;
  const isApiUrl = req.url.startsWith(environment.apiUrl);
  if (isApiUrl && token) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  }

  return next(req).pipe(
    catchError((err) => {
      if (err.status === HttpStatusCode.Unauthorized) {
        userService.logout();
        location.reload();
      }

      const error = err.error.message || err.statusText;
      return throwError(() => new Error(err));
    }),
  );
};
