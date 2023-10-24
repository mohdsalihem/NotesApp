using Microsoft.AspNetCore.Mvc;
using NotesApp.Server.Helpers;
using NotesApp.Server.Services.Interfaces;

namespace NotesApp.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("{username}"), AllowAnonymous]
    public async Task<ActionResult<bool>> IsUsernameExist(string username)
    {
        return Ok(await userService.IsUsernameExist(username));
    }
}