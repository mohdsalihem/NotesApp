import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpEventType,
} from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { UserService } from '../services/user.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private userService: UserService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const currentUser = this.userService.currentUser.value;
    const token = currentUser && currentUser.token ? currentUser.token : null;
    const isApiUrl = request.url.startsWith(environment.apiUrl);
    if (isApiUrl && token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }

    return next.handle(request).pipe(
      catchError((err) => {
        if (err.status === 401) {
          // auto logout if 401 response returned from api
          this.userService.logout();
          location.reload();
        }

        const error = err.error.message || err.statusText;
        return throwError(() => new Error(err));
      })
    );
  }
}
