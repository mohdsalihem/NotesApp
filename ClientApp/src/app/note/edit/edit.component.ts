import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { INote } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styles: [],
})
export class EditComponent implements OnInit {
  id = new FormControl();
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

  editNoteForm = new FormGroup({
    id: this.id,
    title: this.title,
    description: this.description,
  });

  constructor(
    private noteService: NoteService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService.getNoteById(id).subscribe((data) => {
      this.id.setValue(data.noteId);
      this.title.setValue(data.title);
      this.description.setValue(data.description);
    });
  }

  updateNote() {
    const note: INote = {
      noteId: this.id.value,
      title: this.title.value!,
      description: this.description.value!,
      modifiedDate: new Date(),
    };
    this.noteService.updateNote(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
