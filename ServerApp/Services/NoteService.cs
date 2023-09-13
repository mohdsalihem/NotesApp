using AutoMapper;
using ServerApp.Dtos;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using ServerApp.Services.Interfaces;

namespace ServerApp.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository noteRepository;
    private readonly IMapper mapper;

    public NoteService(INoteRepository noteRepository, IMapper mapper)
    {
        this.noteRepository = noteRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Note>> GetAll()
    {
        return await noteRepository.GetAll();
    }

    public async Task<Note> Get(int id)
    {
        return await noteRepository.Get(id);
    }

    public async Task<int> Insert(NoteRequestDto noteRequest)
    {
        Note note = mapper.Map<Note>(noteRequest);

        return await noteRepository.Insert(note);
    }

    public async Task<int> Update(NoteRequestDto noteRequest)
    {
        Note note = mapper.Map<Note>(noteRequest);

        return await noteRepository.Update(noteRequest);
    }

    public async Task<int> Delete(int id)
    {
        return await noteRepository.Delete(id);
    }
}
