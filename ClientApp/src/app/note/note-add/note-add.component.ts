import { Component, OnInit, inject } from '@angular/core';
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

@Component({
  selector: 'app-note-add',
  templateUrl: './note-add.component.html',
  styles: [],
  standalone: true,
  imports: [ReactiveFormsModule, InputComponent, RouterLink],
})
export class NoteAddComponent implements OnInit {
  noteService = inject(NoteService);
  router = inject(Router);
  userService = inject(UserService);

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
    this.noteService.add(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
