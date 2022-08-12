import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteRoutingModule } from './note-routing.module';
import { NotesComponent } from './notes/notes.component';
import { EditComponent } from './edit/edit.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { DeleteComponent } from './delete/delete.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [NotesComponent, EditComponent, DeleteComponent, AddComponent],
  imports: [CommonModule, NoteRoutingModule, SharedModule, ReactiveFormsModule],
})
export class NoteModule {}
