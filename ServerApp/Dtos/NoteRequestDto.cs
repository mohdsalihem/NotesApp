namespace ServerApp.Dtos;

public class NoteRequestDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
