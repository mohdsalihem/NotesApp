using ServerApp.Data;
using ServerApp.Entities;

namespace ServerApp.Interfaces
{
    public interface INoteService
    {
        List<Note> GetUserNotes(int userId);
        Note GetNote(int noteId, int userId);
        void UpdateNote(Note note, int userId);
        void DeleteNote(int noteId, int userId);
        Note AddNote(Note note, int userId);
        void DbContext(DataContext context);
    }
}