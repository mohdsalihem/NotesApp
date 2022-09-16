using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.Entities;
using ServerApp.Interfaces;

namespace ServerApp.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, DataContext context)
        {
            _userService = userService;
            _userService.DbContext(context);
        }

        [HttpPost]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            try
            {
                var response = _userService.Login(request);

                if (response == null)
                {
                    return Ok("Username or Password is incorrect");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Signup([FromBody] User user)
        {
            try
            {
                var response = _userService.Signup(user);

                if (response == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Username or Password is incorrect");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }

        }

        [HttpGet]
        public IActionResult CheckUsernameExist(string username)
        {
            var response = _userService.CheckUsernameExist(username);
            return new JsonResult(response);
        }
    }
}