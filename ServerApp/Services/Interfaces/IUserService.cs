using ServerApp.Models;
using ServerApp.Entities;

namespace ServerApp.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponse> Login(LoginRequest request);
    Task<LoginResponse> Signup(SignupRequest signupRequest);
    Task<bool> IsUsernameExist(string username);
}