using Microsoft.AspNetCore.Mvc;
using ServerApp.Dtos;
using ServerApp.Models;
using ServerApp.Services.Interfaces;

namespace ServerApp.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly INoteService noteService;

    public NoteController(INoteService noteService)
    {
        this.noteService = noteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetAll()
    {
        return Ok(await noteService.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<Note>>> Get(int id)
    {
        return Ok(await noteService.Get(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Insert(NoteRequestDto noteRequest)
    {
        return CreatedAtAction(nameof(Insert), await noteService.Insert(noteRequest));
    }

    [HttpPut]
    public async Task<ActionResult<int>> Update(NoteRequestDto noteRequest)
    {
        return Ok(await noteService.Update(noteRequest));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        return Ok(await noteService.Delete(id));
    }
}
