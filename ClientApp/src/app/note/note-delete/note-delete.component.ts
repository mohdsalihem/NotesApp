import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-note-delete',
  templateUrl: './note-delete.component.html',
  styles: [],
  standalone: true,
  imports: [RouterLink],
})
export class DeleteComponent implements OnInit {
  route = inject(ActivatedRoute);
  noteService = inject(NoteService);
  router = inject(Router);
  note!: Note;

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService.get(id).subscribe((note) => {
      this.note = note;
    });
  }

  deleteNote(id: number) {
    this.noteService.delete(id).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}