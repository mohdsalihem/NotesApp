using Microsoft.AspNetCore.Mvc;
using ServerApp.Dtos;
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

    [HttpPost, AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
    {
        return Ok(await userService.Login(request));
    }
    [HttpPost, AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Signup(SignupRequestDto signupRequest)
    {
        var response = await userService.Signup(signupRequest);
        if (response == null)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return CreatedAtAction(nameof(Signup), response);
    }

    [HttpGet("{username}"), AllowAnonymous]
    public async Task<ActionResult<bool>> IsUsernameExist(string username)
    {
        return Ok(await userService.IsUsernameExist(username));
    }
}