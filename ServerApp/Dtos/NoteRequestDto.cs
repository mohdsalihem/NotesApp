using System.ComponentModel.DataAnnotations;

namespace ServerApp.Dtos;

public class NoteRequestDto
{
    public int Id { get; set; }

    [MinLength(3)]
    [MaxLength(100)]
    public required string Title { get; set; }

    [MinLength(3)]
    [MaxLength(250)]
    public required string Description { get; set; }
}
