using Microsoft.AspNetCore.Mvc;
using ServerApp.Interfaces;
using ServerApp.Entities;
using ServerApp.Helpers;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService, DataContext context)
        {
            _noteService = noteService;
            _noteService.DbContext(context);
        }

        [HttpGet]
        public IActionResult GetUserNotes()
        {
            var userId = (int)HttpContext.Items["userId"];
            var notes = _noteService.GetUserNotes(userId);
            return Ok(notes);
        }

        [HttpGet]
        public IActionResult GetNote(int noteId)
        {
            try
            {
                var userId = (int)HttpContext.Items["userId"];
                var note = _noteService.GetNote(noteId, userId);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateNote([FromBody] Note note)
        {
            try
            {
                var userId = (int)HttpContext.Items["userId"];
                _noteService.UpdateNote(note, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteNote(int noteId)
        {
            var userId = (int)HttpContext.Items["userId"];
            _noteService.DeleteNote(noteId, userId);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddNote([FromBody] Note note)
        {
            var userId = (int)HttpContext.Items["userId"];
            var addedNote = _noteService.AddNote(note, userId);
            return Ok(addedNote);
        }
    }
}