

using Data.Models;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Imagehub.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(StringConstants.CORS_POLICY_NAME)]
    [Authorize]
    public class AccountController: ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IFriendService _friendService;

        public AccountController(IAuthService authService, IFriendService friendService)
        {
            _authService = authService;
            _friendService = friendService;
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

        [HttpGet("all")]
        public async Task<ActionResult<UserDto>> GetAllFriendableUsers()
        {
            var loggedInUserId = _authService.GetLoggedinUserId();
            if (loggedInUserId == 0)
            {
                return new StatusCodeResult(500);
            }

            var friendIds = _friendService.GetFriendList(loggedInUserId)
                .Select(f=>f.Id);

            return Ok(await _authService.GetAllUsers()
                .Where(u=>u.Id != loggedInUserId && !friendIds.Contains(u.Id))
                .Select(u => new UserDto() {Id = u.Id, Username = u.UserName })
                .ToListAsync());
        }

       
    }
}
