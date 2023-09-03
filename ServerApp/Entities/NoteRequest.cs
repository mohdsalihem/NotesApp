namespace ServerApp.Entities;

public class NoteRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
