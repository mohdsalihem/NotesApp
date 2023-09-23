import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-note-delete',
  templateUrl: './note-delete.component.html',
  styles: [],
  standalone: true,
  imports: [RouterLink],
})
export class DeleteComponent implements OnInit, OnDestroy {
  route = inject(ActivatedRoute);
  noteService = inject(NoteService);
  router = inject(Router);
  note!: Note;
  destroy$ = new Subject<void>();

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService
      .get(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe((note) => {
        this.note = note;
      });
  }

  deleteNote(id: number) {
    this.noteService
      .delete(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        this.router.navigate(['/']);
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
