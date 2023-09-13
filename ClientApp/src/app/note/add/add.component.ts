import { Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Note } from 'src/app/models/note';
import { UserService } from 'src/app/services/user.service';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styles: [],
})
export class AddComponent implements OnInit {
  title = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(100),
  ]);
  description = new FormControl('', [
    Validators.required,
    Validators.minLength(3),
    Validators.maxLength(250),
  ]);

  addNoteForm = new FormGroup({
    title: this.title,
    description: this.description,
  });

  noteService = inject(NoteService);
  router = inject(Router);
  userService = inject(UserService);

  ngOnInit(): void {}

  addNote() {
    const note: Note = {
      title: this.title.value!,
      description: this.description.value!,
    };
    this.noteService.add(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
