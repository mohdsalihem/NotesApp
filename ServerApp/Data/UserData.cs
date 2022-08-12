using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Entities;

namespace ServerApp.Data
{
    public class UserData
    {
        public static List<User> Values = new List<User>()
        {
            new User() {
                userId = 1,
                firstName = "Test",
                lastName = "User",
                username = "test",
                password = "test"
            }
        };
    }
}