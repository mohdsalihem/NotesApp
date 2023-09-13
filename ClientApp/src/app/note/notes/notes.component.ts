import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { NgFor, DatePipe } from '@angular/common';

@Component({
    selector: 'app-notes',
    templateUrl: './notes.component.html',
    styles: [],
    standalone: true,
    imports: [NgFor, DatePipe],
})
export class NotesComponent implements OnInit {
  noteService = inject(NoteService);
  router = inject(Router);

  notes: Note[] = [];
  allNotes: Note[] = [];

  ngOnInit(): void {
    this.noteService.getAll().subscribe((notes) => {
      this.allNotes = notes;
      this.notes = notes;
    });
  }

  edit(id: number) {
    this.router.navigate(['note/edit', id]);
  }

  deleteNote(id: number) {
    this.router.navigate(['note/delete', id]);
  }

  add() {
    this.router.navigate(['note/add']);
  }
  search(term: string) {
    if (!term) {
      this.notes = this.allNotes;
    }

    this.notes = this.allNotes.filter((note) =>
      note.title.toLowerCase().includes(term.toLowerCase()),
    );
  }
}
