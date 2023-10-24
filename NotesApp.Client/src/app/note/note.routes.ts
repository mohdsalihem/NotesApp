import { Route } from '@angular/router';
import { NoteListComponent } from './note-list/note-list.component';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { NoteDeleteComponent } from './note-delete/note-delete.component';
import { NoteAddComponent } from './note-add/note-add.component';

export default [
  { path: '', component: NoteListComponent },
  { path: 'edit/:id', component: NoteEditComponent },
  { path: 'delete/:id', component: NoteDeleteComponent },
  { path: 'add', component: NoteAddComponent },
] as Route[];
