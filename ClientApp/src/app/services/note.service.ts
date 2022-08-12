import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { INote } from '../models/note';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  constructor(private http: HttpClient) {}

  apiUrl = environment.apiUrl + '/Note';

  getAllNotes() {
    return this.http.get<INote[]>(`${this.apiUrl}/GetUserNotes`);
  }

  getNoteById(id: number) {
    return this.http.get<INote>(`${this.apiUrl}/GetNote`, {
      params: {
        noteId: id,
      },
    });
  }

  updateNote(note: INote) {
    return this.http.put<string>(`${this.apiUrl}/UpdateNote`, note);
  }

  deleteNote(id: number) {
    return this.http.delete(`${this.apiUrl}/DeleteNote`, {
      params: {
        noteId: id,
      },
    });
  }

  addNote(note: INote) {
    return this.http.post<INote>(`${this.apiUrl}/AddNote`, note);
  }
}
