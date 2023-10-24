using SqlKata;

namespace NotesApp.Server.Models;

public class BaseModel
{
    [Key]
    [Ignore]
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsArchived { get; set; }
}
