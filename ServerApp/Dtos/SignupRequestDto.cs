using System.ComponentModel.DataAnnotations;

namespace ServerApp.Dtos;

public class SignupRequestDto : LoginRequestDto
{
    [MinLength(3)]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public required string LastName { get; set; }
}
