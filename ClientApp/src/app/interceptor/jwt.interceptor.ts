import { inject } from '@angular/core';
import {
  HttpInterceptorFn,
  HttpRequest,
  HttpStatusCode,
} from '@angular/common/http';
import { catchError, switchMap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../services/auth.service';
import { TokenService } from '../services/token.service';

export const JwtInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const tokenService = inject(TokenService);
  const currentUser = authService.currentUser$.value;
  const isApiUrl = req.url.startsWith(environment.apiUrl);
  let isrefreshed = false;

  const addToken = (req: HttpRequest<unknown>, token: string) => {
    return req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  };

  if (isApiUrl && currentUser?.token) {
    req = addToken(req, currentUser?.token);
  }

  return next(req).pipe(
    catchError((err) => {
      if (err.status === HttpStatusCode.Unauthorized && !isrefreshed) {
        isrefreshed = true;
        return tokenService.refresh().pipe(
          switchMap((user) => {
            if (user.token) {
              authService.setCurrentUser(user);
              req = addToken(req, user.token);
              return next(req);
            }

            return throwError(() => new Error('Token not found'));
          }),
        );
      }

      authService.logout();
      tokenService.revoke();
      location.reload();
      return throwError(() => new Error(err));
    }),
  );
};
