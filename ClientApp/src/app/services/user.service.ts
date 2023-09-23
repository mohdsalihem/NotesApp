import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/user';

  isUsernameExist(username: string) {
    return this.http.get<boolean>(`${this.apiUrl}/isUsernameExist/${username}`);
  }
}
