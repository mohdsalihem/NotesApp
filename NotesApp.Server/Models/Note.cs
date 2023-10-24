namespace NotesApp.Server.Models
{
    public class Note : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int UserId { get; set; }
    }
}