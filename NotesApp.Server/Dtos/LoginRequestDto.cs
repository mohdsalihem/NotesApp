using System.ComponentModel.DataAnnotations;

namespace NotesApp.Server.Dtos;

public class LoginRequestDto
{
    [MinLength(3)]
    [MaxLength(50)]
    public required string Username { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public required string Password { get; set; }
}