using SqlKata;

namespace ServerApp.Models;

public class RefreshToken
{
    [Key]
    [Ignore]
    public int Id { get; set; }

    public required int UserId { get; set; }
    public required string Token { get; set; }
    public required DateTime ExpiryDate { get; set; }
}
