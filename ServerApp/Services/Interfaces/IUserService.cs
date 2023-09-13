using ServerApp.Dtos;

namespace ServerApp.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponseDto> Login(LoginRequestDto request);
    Task<LoginResponseDto> Signup(SignupRequestDto signupRequest);
    Task<bool> IsUsernameExist(string username);
}