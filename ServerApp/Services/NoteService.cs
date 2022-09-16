using ServerApp.Interfaces;
using ServerApp.Entities;
using ServerApp.Data;

namespace ServerApp.Services
{
    public class NoteService : INoteService
    {
        private DataContext _context;
        public List<Note> GetUserNotes(int userId)
        {
            return _context.Notes.Where(x => x.userId == userId).ToList();
        }

        public Note GetNote(int noteId, int userId)
        {
            var note = _context.Notes.FirstOrDefault(x => x.noteId == noteId && x.userId == userId);
            if (note is null)
            {
                throw new Exception("Note not found.");
            }
            return note;
        }

        public void UpdateNote(Note note, int userId)
        {
            var oldNote = _context.Notes.FirstOrDefault(x => x.noteId == note.noteId && x.userId == userId);

            if (oldNote is null)
            {
                throw new Exception("Note not found. Can't update data.");
            }

            oldNote.title = note.title;
            oldNote.description = note.description;
            oldNote.modifiedDate = note.modifiedDate;
            _context.Notes.Update(oldNote);
            _context.SaveChanges();
        }

        public void DeleteNote(int noteId, int userId)
        {
            var note = _context.Notes.FirstOrDefault(x => x.noteId == noteId && x.userId == userId);

            if (note is null)
            {
                throw new Exception("Note not found. Can't delete data.");
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public Note AddNote(Note note, int userId)
        {
            note.userId = userId;
            note.createdDate = DateTime.Now;
            note.modifiedDate = DateTime.Now;
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void DbContext(DataContext context)
        {
            _context = context;
        }
    }
}