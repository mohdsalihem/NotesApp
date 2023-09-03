using ServerApp.Entities;
using ServerApp.Models;

namespace ServerApp.Services.Interfaces;

public interface INoteService
{
    Task<IEnumerable<Note>> GetAll();
    Task<Note> Get(int id);
    Task<int> Insert(NoteRequest noteRequest);
    Task<int> Update(NoteRequest noteRequest);
    Task<int> Delete(int id);
}
