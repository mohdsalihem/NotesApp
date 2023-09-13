import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteRoutingModule } from './note-routing.module';
import { NotesComponent } from './notes/notes.component';
import { EditComponent } from './edit/edit.component';

import { ReactiveFormsModule } from '@angular/forms';
import { DeleteComponent } from './delete/delete.component';
import { AddComponent } from './add/add.component';

@NgModule({
    imports: [CommonModule, NoteRoutingModule, ReactiveFormsModule, NotesComponent, EditComponent, DeleteComponent, AddComponent],
})
export class NoteModule {}
