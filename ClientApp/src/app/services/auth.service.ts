import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/auth';
  private readonly CURRENT_USER = 'currentUser';

  public currentUser$ = new BehaviorSubject<User | null>(
    JSON.parse(localStorage.getItem(this.CURRENT_USER)!),
  );

  login(username: string, password: string) {
    return this.http
      .post<User>(
        `${this.apiUrl}/login`,
        { username, password },
        { withCredentials: true },
      )
      .pipe(
        map((user) => {
          if (user?.token) {
            this.setCurrentUser(user);
            return true;
          }
          return false;
        }),
      );
  }

  signup(user: User) {
    return this.http.post<User>(`${this.apiUrl}/signup`, user).pipe(
      map((user) => {
        if (user?.token) {
          this.setCurrentUser(user);
          return true;
        }
        return false;
      }),
    );
  }

  logout() {
    this.removeCurrentUser();
  }

  setCurrentUser(currentUser: User) {
    localStorage.setItem(this.CURRENT_USER, JSON.stringify(currentUser));
    this.currentUser$.next(currentUser);
  }

  removeCurrentUser() {
    this.currentUser$.next(null);
    localStorage.removeItem(this.CURRENT_USER);
  }
}
