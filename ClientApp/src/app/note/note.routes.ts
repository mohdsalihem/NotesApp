import { Route } from '@angular/router';
import { NotesComponent } from './note-list/note-list.component';
import { EditComponent } from './note-edit/note-edit.component';
import { DeleteComponent } from './note-delete/note-delete.component';
import { NoteAddComponent } from './note-add/note-add.component';

export default [
  { path: '', component: NotesComponent },
  { path: 'edit/:id', component: EditComponent },
  { path: 'delete/:id', component: DeleteComponent },
  { path: 'add', component: NoteAddComponent },
] as Route[];
