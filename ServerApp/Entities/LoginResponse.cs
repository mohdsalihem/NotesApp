namespace ServerApp.Entities;

public class LoginResponse
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}