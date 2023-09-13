import { Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { InputComponent } from '../../shared/input/input.component';

@Component({
    selector: 'app-edit',
    templateUrl: './edit.component.html',
    styles: [],
    standalone: true,
    imports: [
        ReactiveFormsModule,
        InputComponent,
        RouterLink,
    ],
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

  noteService = inject(NoteService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService.get(id).subscribe((note) => {
      this.id.setValue(note.id);
      this.title.setValue(note.title);
      this.description.setValue(note.description);
    });
  }

  updateNote() {
    const note: Note = {
      id: this.id.value,
      title: this.title.value!,
      description: this.description.value!,
      modifiedDate: new Date(),
    };
    this.noteService.update(note).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
