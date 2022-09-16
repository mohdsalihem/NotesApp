namespace ServerApp.Entities
{
    public class Note
    {
        public int noteId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public int userId { get; set; }
    }
}