using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Entities;

namespace ServerApp.Interfaces
{
    public interface IUserService
    {
        User Login(AuthRequest request);
        User Signup(User user);
        string CheckUsernameExist(string username);
    }
}