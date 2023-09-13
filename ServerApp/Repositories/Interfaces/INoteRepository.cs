using ServerApp.Dtos;
using ServerApp.Models;

namespace ServerApp.Repositories.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAll();
    Task<Note> Get(int id);
    Task<int> Insert(Note note);
    Task<int> Update(NoteRequestDto noteRequest);
    Task<int> Delete(int id);
}
