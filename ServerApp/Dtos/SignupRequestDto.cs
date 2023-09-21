using System.ComponentModel.DataAnnotations;

namespace ServerApp.Dtos;

public class SignupRequestDto
{
    [MinLength(3)]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public required string LastName { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public required string Username { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public required string Password { get; set; }
}
