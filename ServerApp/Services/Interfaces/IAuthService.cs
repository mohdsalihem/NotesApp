using ServerApp.Dtos;

namespace ServerApp.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto request);
    Task<LoginResponseDto> Signup(SignupRequestDto signupRequest);
}
