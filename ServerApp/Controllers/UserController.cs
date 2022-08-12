using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerApp.Entities;
using ServerApp.Interfaces;

namespace ServerApp.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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