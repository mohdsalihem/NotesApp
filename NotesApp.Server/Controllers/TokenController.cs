using Microsoft.AspNetCore.Mvc;
using NotesApp.Server.Dtos;
using NotesApp.Server.Helpers;
using NotesApp.Server.Services.Interfaces;

namespace NotesApp.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenService tokenService;

    public TokenController(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Refresh()
    {
        return Ok(await tokenService.Refresh());
    }

    [HttpDelete]
    public async Task<ActionResult<int>> Revoke()
    {
        return Ok(await tokenService.Revoke());
    }

    [HttpDelete]
    public async Task<ActionResult<int>> RevokeAll()
    {
        return Ok(await tokenService.RevokeAll());
    }
}
