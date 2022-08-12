import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { AddComponent } from './add/add.component';
import { NotesComponent } from './notes/notes.component';
import { DeleteComponent } from './delete/delete.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/note', pathMatch: 'full' },
  { path: 'note', component: NotesComponent, canActivate: [AuthGuard] },
  { path: 'note/edit/:id', component: EditComponent },
  { path: 'note/delete/:id', component: DeleteComponent },
  { path: 'note/add', component: AddComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NoteRoutingModule {}
