using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Interfaces;
using ServerApp.Entities;
using ServerApp.Data;

namespace ServerApp.Services
{
    public class NoteService : INoteService
    {
        public List<Note> GetUserNotes(int userId)
        {
            return NoteData.Values.Where(x => x.userId == userId).ToList();
        }

        public Note GetNote(int noteId, int userId)
        {
            var note = NoteData.Values.FirstOrDefault(x => x.noteId == noteId && x.userId == userId);
            if (note is null)
            {
                throw new Exception("Note not found.");
            }
            return note;
        }

        public void UpdateNote(Note note, int userId)
        {
            var oldNote = NoteData.Values.FirstOrDefault(x => x.noteId == note.noteId && x.userId == userId);

            if (oldNote is null)
            {
                throw new Exception("Note not found. Can't update data.");
            }

            oldNote.title = note.title;
            oldNote.description = note.description;
            oldNote.modifiedDate = note.modifiedDate;
        }

        public void DeleteNote(int noteId, int userId)
        {
            NoteData.Values.RemoveAll(x => x.noteId == noteId && x.userId == userId);
        }

        public Note AddNote(Note note, int userId)
        {
            note.noteId = NoteData.Values.Max(x => x.noteId) + 1;
            note.userId = userId;
            note.createdDate = DateTime.Now;
            note.modifiedDate = DateTime.Now;
            NoteData.Values.Add(note);
            return note;
        }
    }
}