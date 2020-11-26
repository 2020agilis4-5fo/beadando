

using Data.Models;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
                    var user = await _authService.GetAllUsers()
                        .Where(u => u.Id == result.UserId)
                        .SingleOrDefaultAsync();

                    return Ok(new 
                    { 
                        Userid = user.Id,
                        Username = user.UserName
                    });
                }

            }
            return BadRequest(ModelState);
        }

        [HttpGet("login/{callback}")]
        [AllowAnonymous]
        public IActionResult Login(string callback)
        {
            var redirectUrl = Url.Action(nameof(AccountController.LoginCallback), "Account");
            return Challenge(new AuthenticationProperties { RedirectUri = redirectUrl }, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("callback")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCallback() => 
             Ok(await _authService.AttemptLoginWithFacebookAsync());
        

        [HttpPost("logout")]
        public async Task<IActionResult> Logout() =>
            Ok(await _authService.AttemptLogoutAsync());


        [HttpGet("all")]
        public async Task<ActionResult<UserDto>> GetAllFriendableUsers() => 
            Ok(await _authService.GetAllFriendableUsers()
                .Select(u => new UserDto() { Id = u.Id, Username = u.UserName })
                .ToListAsync());



    }
}
