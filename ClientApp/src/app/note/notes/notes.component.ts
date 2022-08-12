import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { INote } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styles: [],
})
export class NotesComponent implements OnInit {
  constructor(private noteService: NoteService, private router: Router) {}
  notes: INote[] = [];
  allNotes: INote[] = [];

  ngOnInit(): void {
    this.noteService.getAllNotes().subscribe((data) => {
      this.allNotes = data;
      this.notes = data;
    });
  }

  editNote(id: number) {
    this.router.navigate(['note/edit', id]);
  }

  deleteNote(id: number) {
    this.router.navigate(['note/delete', id]);
  }

  addNote() {
    this.router.navigate(['note/add']);
  }
  searchTerm(term: string) {
    if (!term) {
      this.notes = this.allNotes;
    }

    this.notes = this.allNotes.filter((note) =>
      note.title.toLowerCase().includes(term.toLowerCase())
    );
  }
}
