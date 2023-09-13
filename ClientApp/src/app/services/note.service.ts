import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { Note } from '../models/note';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  http = inject(HttpClient);

  apiUrl = environment.apiUrl + '/Note';

  getAll() {
    return this.http.get<Note[]>(`${this.apiUrl}/GetAll`);
  }

  get(id: number) {
    return this.http.get<Note>(`${this.apiUrl}/Get/${id}`);
  }

  update(note: Note) {
    return this.http.put<number>(`${this.apiUrl}/Update`, note);
  }

  delete(id: number) {
    return this.http.delete<number>(`${this.apiUrl}/Delete/${id}`);
  }

  add(note: Note) {
    return this.http.post<Note>(`${this.apiUrl}/Insert`, note);
  }
}
