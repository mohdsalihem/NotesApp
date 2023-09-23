import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { Note } from '../models/note';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/note';

  getAll() {
    return this.http.get<Note[]>(`${this.apiUrl}/getAll`);
  }

  get(id: number) {
    return this.http.get<Note>(`${this.apiUrl}/get/${id}`);
  }

  update(note: Note) {
    return this.http.put<number>(`${this.apiUrl}/update`, note);
  }

  delete(id: number) {
    return this.http.delete<number>(`${this.apiUrl}/delete/${id}`);
  }

  insert(note: Note) {
    return this.http.post<Note>(`${this.apiUrl}/insert`, note);
  }
}
