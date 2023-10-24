using NotesApp.Server.Dtos;
using NotesApp.Server.Helpers;
using NotesApp.Server.Helpers.Interfaces;
using NotesApp.Server.Models;
using NotesApp.Server.Repositories.Interfaces;
using SqlKata.Execution;

namespace NotesApp.Server.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly IGenericRepository<Note> genericRepository;
    private readonly IDbAccessor dbAccessor;
    private readonly IHttpContextHelper httpContextHelper;
    public NoteRepository(IGenericRepository<Note> genericRepository, IHttpContextHelper httpContextHelper, IDbAccessor dbAccessor)
    {
        this.genericRepository = genericRepository;
        this.httpContextHelper = httpContextHelper;
        this.dbAccessor = dbAccessor;
    }
    public async Task<IEnumerable<Note>> GetAll()
    {
        return await genericRepository.GetAll();
    }

    public async Task<Note> Get(int id)
    {
        return await genericRepository.Get(id);
    }

    public async Task<int> Insert(Note note)
    {
        note.UserId = httpContextHelper.UserId;
        return await genericRepository.Insert(note);
    }

    public async Task<int> Update(NoteRequestDto request)
    {
        return await dbAccessor.Factory
                    .Query<Note>()
                    .Where(new
                    {
                        id = request.Id,
                        userid = httpContextHelper.UserId
                    })
                    .UpdateAsync(new
                    {
                        title = request.Title,
                        description = request.Description,
                        modifieddate = DateTime.UtcNow
                    });
    }

    public async Task<int> Delete(int id)
    {
        return await genericRepository.Delete(id);
    }
}
