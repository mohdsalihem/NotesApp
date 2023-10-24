import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/token';

  refresh() {
    return this.http.get<User>(`${this.apiUrl}/refresh`, {
      withCredentials: true,
    });
  }

  revoke() {
    return this.http.delete<number>(`${this.apiUrl}/revoke`, {
      withCredentials: true,
    });
  }

  revokeAll() {
    return this.http.delete<number>(`${this.apiUrl}/revokeAll`, {
      withCredentials: true,
    });
  }
}
