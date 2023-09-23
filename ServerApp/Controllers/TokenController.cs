using Microsoft.AspNetCore.Mvc;
using ServerApp.Dtos;
using ServerApp.Helpers;
using ServerApp.Services.Interfaces;

namespace ServerApp.Controllers;

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
