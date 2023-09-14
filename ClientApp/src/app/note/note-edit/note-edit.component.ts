import { Component, OnInit, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { InputComponent } from '../../shared/input/input.component';

@Component({
  selector: 'app-note-edit',
  templateUrl: './note-edit.component.html',
  styles: [],
  standalone: true,
  imports: [ReactiveFormsModule, InputComponent, RouterLink],
})
export class EditComponent implements OnInit {
  noteService = inject(NoteService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  editNoteForm = new FormGroup({
    id: new FormControl(0, {
      nonNullable: true,
      validators: Validators.required,
    }),
    title: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(100),
      ],
    }),
    description: new FormControl('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(250),
      ],
    }),
  });

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService.get(id).subscribe((note) => {
      this.editNoteForm.setValue({
        id: note.id!,
        title: note.title,
        description: note.description,
      });
    });
  }

  edit() {
    const note = this.editNoteForm.value as Note;
    this.noteService.update(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
