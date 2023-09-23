using Microsoft.AspNetCore.Mvc;
using ServerApp.Helpers;
using ServerApp.Services.Interfaces;

namespace ServerApp.Controllers;

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