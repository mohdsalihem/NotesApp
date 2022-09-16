using System.ComponentModel.DataAnnotations;

namespace ServerApp.Entities
{
    public class AuthRequest
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}