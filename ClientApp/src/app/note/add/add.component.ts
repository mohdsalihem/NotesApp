import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { INote } from 'src/app/models/note';
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

  constructor(
    private noteService: NoteService,
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void {}

  addNote() {
    const note: INote = {
      title: this.title.value!,
      description: this.description.value!,
    };
    this.noteService.addNote(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
