import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public currentUser$ = new BehaviorSubject<User | null>(null);
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/User';

  login(username: string, password: string) {
    return this.http
      .post<User>(`${this.apiUrl}/Login`, { username, password })
      .pipe(
        map((user) => {
          if (user?.token) {
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUser$.next(user);
            return true;
          }
          return false;
        }),
      );
  }

  signup(user: User) {
    return this.http.post<User>(`${this.apiUrl}/Signup`, user).pipe(
      map((user) => {
        if (user?.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUser$.next(user);
          return true;
        }
        return false;
      }),
    );
  }

  logout() {
    this.currentUser$.next(null);
    localStorage.removeItem('currentUser');
  }

  isUsernameExist(username: string) {
    return this.http.get<string>(`${this.apiUrl}/IsUsernameExist`, {
      params: {
        username: username,
      },
    });
  }
}
