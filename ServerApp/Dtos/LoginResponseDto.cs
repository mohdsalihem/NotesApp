namespace ServerApp.Dtos;

public class LoginResponseDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}