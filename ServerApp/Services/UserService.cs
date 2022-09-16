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
        private DataContext _context;
        public UserService(IOptions<Credentials> credentials)
        {
            _credentials = credentials.Value;
        }

        public AuthResponse Login(AuthRequest request)
        {
            var user = _context.Users.SingleOrDefault(x => x.username == request.username && x.password == request.password);
            if (user == null) return null;

            var JwtToken = generateJwtToken(user);

            return new AuthResponse()
            {
                userId = user.userId,
                firstName = user.firstName,
                lastName = user.lastName,
                username = user.username,
                token = JwtToken
            };
        }

        public AuthResponse Signup(User user)
        {

            if (_context.Users.Any(x => x.username == user.username))
            {
                throw new Exception("Username already exist. Please try another username.");
            }

            _context.Users.Add(new User()
            {
                firstName = user.firstName,
                lastName = user.lastName,
                username = user.username,
                password = user.password
            });
            _context.SaveChanges();

            var authRequest = new AuthRequest()
            {
                username = user.username,
                password = user.password
            };
            return Login(authRequest);
        }

        public string CheckUsernameExist(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.username == username);
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

        public void DbContext(DataContext context)
        {
            _context = context;
        }
    }
}