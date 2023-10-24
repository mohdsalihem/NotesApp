using NotesApp.Server.Dtos;
using NotesApp.Server.Models;

namespace NotesApp.Server.Repositories.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAll();
    Task<Note> Get(int id);
    Task<int> Insert(Note note);
    Task<int> Update(NoteRequestDto noteRequest);
    Task<int> Delete(int id);
}
