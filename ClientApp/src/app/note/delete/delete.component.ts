import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { INote } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styles: [],
})
export class DeleteComponent implements OnInit {
  note!: INote;
  constructor(
    private route: ActivatedRoute,
    private noteService: NoteService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    this.noteService.getNoteById(id).subscribe((data) => {
      this.note = data;
    });
  }

  deleteNote(id: number) {
    this.noteService.deleteNote(id).subscribe((data) => {
      this.router.navigate(['/']);
    });
  }
}
