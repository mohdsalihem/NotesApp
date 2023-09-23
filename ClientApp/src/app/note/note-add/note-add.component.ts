import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Note } from 'src/app/models/note';
import { UserService } from 'src/app/services/user.service';
import { NoteService } from 'src/app/services/note.service';
import { InputComponent } from '../../shared/input/input.component';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-note-add',
  templateUrl: './note-add.component.html',
  styles: [],
  standalone: true,
  imports: [ReactiveFormsModule, InputComponent, RouterLink],
})
export class NoteAddComponent implements OnInit, OnDestroy {
  noteService = inject(NoteService);
  router = inject(Router);
  userService = inject(UserService);
  destroy$ = new Subject<void>();

  addNoteForm = new FormGroup({
    title: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(100),
      ],
    }),
    description: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(250),
    ]),
  });

  ngOnInit(): void {}

  add() {
    const note = this.addNoteForm.value as Note;
    this.noteService
      .insert(note)
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
