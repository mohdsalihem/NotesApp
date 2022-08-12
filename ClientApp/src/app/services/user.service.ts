import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public currentUser: BehaviorSubject<IUser | null>;
  constructor(private http: HttpClient) {
    this.currentUser = new BehaviorSubject<IUser | null>(
      JSON.parse(localStorage.getItem('currentUser')!)
    );
  }

  apiUrl = environment.apiUrl + '/User';

  login(username: string, password: string) {
    return this.http
      .post<IUser>(`${this.apiUrl}/Login`, { username, password })
      .pipe(
        map((user) => {
          if (user?.token) {
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUser.next(user);
            return true;
          }
          return false;
        })
      );
  }

  signup(user: IUser) {
    return this.http.post<IUser>(`${this.apiUrl}/Signup`, user).pipe(
      map((user) => {
        if (user?.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUser.next(user);
          return true;
        }
        return false;
      })
    );
  }

  logout() {
    this.currentUser.next(null);
    localStorage.removeItem('currentUser');
  }

  checkUsernameExist(username: string) {
    return this.http.get<string>(`${this.apiUrl}/CheckUsernameExist`, {
      params: {
        username: username,
      },
    });
  }
}
