using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Imagehub.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("img")]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public FriendController(IFriendService friendService, IMapper mapper, IAuthService authService)
        {
            _friendService = friendService;
            _mapper = mapper;
            _authService = authService;
        }
        // GET: api/friend/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendListDto>> GetFriends(int id)
        {
            if (!_authService.CheckIfUserIsAuthorized(id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var friends = _friendService.GetFriendList(id);
            return Ok(new FriendListDto()
            {
                UserId = id,
                Friends = await friends.Select(f => new UserDto() { Id = f.Id, Username = f.UserName})
                        .ToListAsync()
                        
            });
        }

        // GET api/friend/req/from/{id}
        [HttpGet("req/from/{id}")]
        public async Task<ActionResult<RequestSentDto>> GetRequestsSentByUser(int id)
        {
            if (!_authService.CheckIfUserIsAuthorized(id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var requestsSent = _friendService.GetUsersWhomFriendRequestSentBy(id);
            var rec = await requestsSent.Select(f => new UserDto() {Id = f.Id, Username = f.UserName })
                .ToListAsync();
            return new RequestSentDto()
            {
                UserId = id,
                Recipients = rec
            };
        }

        // GET api/friend/req/to/{id}
        [HttpGet("req/to/{id}")]
        public async Task<ActionResult<RequestSentDto>> GetRequestsSentToUser(int id)
        {
            if (!_authService.CheckIfUserIsAuthorized(id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var requestsSent = _friendService.GetUsersWhomFriendRequestSentTo(id);
            return new RequestSentDto()
            {
                UserId = id,
                Recipients = await requestsSent.Select(f => new UserDto() {Id = f.Id, Username = f.UserName }).ToListAsync(),
            };
        }

        // POST api/friend/req
        [HttpPost("req")]
        public async Task<ActionResult> SendRequest([FromBody] FriendRequestDto dto)
        {
            if (!_authService.CheckIfUserIsAuthorized(dto.FromId))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var requestEntity = _mapper.Map<FriendRequest>(dto);
            await _friendService.SendFriendRequest(requestEntity);
            return Ok();
        }

        // POST api/friend/req/cancel
        [HttpPost("req/cancel")]
        public async Task<ActionResult> CancelFriendRequest([FromBody] FriendRequestDto dto)
        {
            var userId = _authService.GetLoggedinUserId();
            if (dto.FromId != userId && dto.ToId != userId)
            {
                return Unauthorized("Cannot cancel friend request of someone else");
            }

            var requestEntity = _mapper.Map<FriendRequest>(dto);
            await _friendService.CancelFriendRequest(requestEntity);
            return Ok();
        }

        // POST api/friend/req/accept
        [HttpPost("req/accept")]
        public async Task<ActionResult> AcceptFriendRequest([FromBody] FriendRequestDto dto)
        {
            var userId = _authService.GetLoggedinUserId();
            if (dto.FromId != userId && dto.ToId != userId)
            {
                return Unauthorized("Cannot accept friend request of someone else");
            }

            var requestEntity = _mapper.Map<FriendRequest>(dto);
            await _friendService.AcceptFriendRequest(requestEntity);

            return Ok();
        }


        // DELETE api/friend/
        [HttpDelete]
        public async Task<ActionResult> Unfriend([FromBody] UnfriendDto dto)
        {
            var userId = _authService.GetLoggedinUserId();
            if (dto.FromId != userId && dto.ToId != userId)
            {
                return Unauthorized("Cannot unfriend on behalf of someone else");
            }

            var unfriendRequest = _mapper.Map<Friend>(dto);
            await _friendService.Unfriend(unfriendRequest);

            return Ok();
        }

    }
}
