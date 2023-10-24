using NotesApp.Server.Dtos;

namespace NotesApp.Server.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto request);
    Task<LoginResponseDto> Signup(SignupRequestDto signupRequest);
}
