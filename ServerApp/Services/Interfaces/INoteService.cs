using ServerApp.Dtos;
using ServerApp.Models;

namespace ServerApp.Services.Interfaces;

public interface INoteService
{
    Task<IEnumerable<Note>> GetAll();
    Task<Note> Get(int id);
    Task<int> Insert(NoteRequestDto noteRequest);
    Task<int> Update(NoteRequestDto noteRequest);
    Task<int> Delete(int id);
}
