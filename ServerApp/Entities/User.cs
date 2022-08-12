using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerApp.Entities
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string token { get; set; }

        public string password { get; set; }
        public User()
        {

        }
        public User(User user, string JwtToken)
        {
            userId = user.userId;
            firstName = user.firstName;
            lastName = user.lastName;
            username = user.username;
            token = JwtToken;
        }
    }
}