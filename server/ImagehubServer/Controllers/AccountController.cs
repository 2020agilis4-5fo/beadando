using Flurl.Http;
using Flurl;
using Imagehub.Core.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Common.Dto;

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
        private readonly IConfiguration _configuration;

        public AccountController(IAuthService authService, IFriendService friendService, IConfiguration configuration)
        {
            _authService = authService;
            _friendService = friendService;
            _configuration = configuration;
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


        [HttpPost("callback")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCallback(FacebookLoginDto dto)
        {
            var tokenExchangeResponse = await "https://graph.facebook.com/oauth/access_token"
                .SetQueryParams(new
                {
                    client_id = _configuration[Constants.FB_ID],
                    client_secret = _configuration[Constants.FB_SECRET],
                    grant_type = "client_credentials"
                })
                .GetJsonAsync<FbAccessToken>();


            var response = await "https://graph.facebook.com/debug_token"
                .SetQueryParams(new
                {
                    input_token = dto.AccessToken,
                    access_token = tokenExchangeResponse.Access_Token
                })
                .GetJsonAsync();

            var fbData = new FBData()
            {
                App_id = response.data.app_id,
                Is_valid = response.data.is_valid,
                User_id = response.data.user_id
            };

            if (_authService.ValidateFbData(fbData, dto))
            {
                return Ok(await _authService.AttemptLoginWithFacebookAsync(dto));
            }

            return Unauthorized(); 
        }
             
        

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
