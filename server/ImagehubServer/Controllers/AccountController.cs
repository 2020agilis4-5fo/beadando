

using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Imagehub.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("img")]
    [Authorize]
    public class AccountController: ControllerBase
    {

        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] LoginDto registerObj)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.AttemptRegisterAsync(registerObj);
                if (!result.Successful)
                {
                    return StatusCode(500);
                }
                else
                {
                    return Ok(result.UserId);
                }

            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginObject)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.AttemptLoginAsync(loginObject);
                if (result.Successful)
                {
                    return Ok(result.UserId);
                }

                return Unauthorized("Incorrect username or password");
            }
            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _authService.AttemptLogoutAsync();
            return Ok(result);
        }

       
    }
}
