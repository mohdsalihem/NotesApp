using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Interfaces;
using ServerApp.Entities;
using Microsoft.Extensions.Options;
using ServerApp.Helpers;
using ServerApp.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ServerApp.Services
{
    public class UserService : IUserService
    {
        private readonly Credentials _credentials;
        public UserService(IOptions<Credentials> credentials)
        {
            _credentials = credentials.Value;
        }

        public User Login(AuthRequest request)
        {
            var user = UserData.Values.SingleOrDefault(x => x.username == request.username && x.password == request.password);

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new User(user, token);
        }

        public User Signup(User user)
        {
            if (UserData.Values.Any(x => x.username == user.username))
            {
                throw new Exception("Username already exist. Please try another username.");
            }
            UserData.Values.Add(new User()
            {
                userId = UserData.Values.Max(x => x.userId) + 1,
                firstName = user.firstName,
                lastName = user.lastName,
                username = user.username,
                password = user.password
            });

            var authRequest = new AuthRequest()
            {
                username = user.username,
                password = user.password
            };
            return Login(authRequest);
        }

        public string CheckUsernameExist(string username)
        {
            var user = UserData.Values.FirstOrDefault(x => x.username == username);
            if (user is null) return null;

            return user.username;
        }

        // Helper methods
        private string generateJwtToken(User user)
        {
            // Generate token that is valid for 2 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_credentials.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}