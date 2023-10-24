using Microsoft.AspNetCore.Mvc;
using NotesApp.Server.Dtos;
using NotesApp.Server.Helpers;
using NotesApp.Server.Services.Interfaces;

namespace NotesApp.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController, AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
    {
        return Ok(await authService.Login(request));
    }
    [HttpPost]
    public async Task<ActionResult<LoginResponseDto>> Signup(SignupRequestDto signupRequest)
    {
        var response = await authService.Signup(signupRequest);
        if (response == null)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return CreatedAtAction(nameof(Signup), response);
    }
}
