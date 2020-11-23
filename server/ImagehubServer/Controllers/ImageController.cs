using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Models;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace ImagehubServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("img")]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageService _service;
        private readonly IFriendService _friendService;
        private readonly IAuthService _authService;

        public ImageController(IMapper mapper, IImageService service, IFriendService friendService, IAuthService authService)
        {
            _mapper = mapper;
            _service = service;
            _friendService = friendService;
            _authService = authService;
        }
        // POST api/values/
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<ImageResponseDto>>> GetImage(int id, [FromBody] UserDto dto)
        {

            if (!_authService.CheckIfUserIsAuthorized(dto.Id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var element = await _service.GetElementAsync(id);
            if (element == null)
            {
                return NotFound(id);
            }

            if (element.OwnerId != dto.Id)
            {
                return Unauthorized("Cannot access data of someone else");
            }

            return Ok(_mapper.Map<ImageResponseDto>(element));
        }

        // GET api/values
        [HttpGet("friends/{id}")]
        public async Task<ActionResult<FriendImagesListDto>> GetImagesOfFriends(int id)
        {
            if (!_authService.CheckIfUserIsAuthorized(id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            var friendIds = await _friendService.GetFriendList(id)       
                .Select(f => f.Id)
                .ToListAsync();

            if (friendIds.Any())
            {
                return Ok(new FriendImagesListDto()
                {
                    UserId = id,
                    FriendImages = await _service.GetElementsAsync()
                        .Where(img => friendIds.Contains(img.OwnerId))
                        .Include(img => img.Owner)
                        .Select(elem => _mapper.Map<ImageResponseDto>(elem))
                        .ToListAsync()
                });
            }
            else
            {
                return Ok(new FriendImagesListDto()
                {
                    UserId = id
                });
            }          
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ImageResponseDto>> GetImages([FromBody] UserDto dto)
        {
            if (!_authService.CheckIfUserIsAuthorized(dto.Id))
            {
                return Unauthorized("Cannot access data of someone else");
            }

            return Ok(await _service.GetElementsAsync()
                .Where(img => img.OwnerId == dto.Id)
                .Include(img=> img.Owner)
                .Select(elem => _mapper.Map<ImageResponseDto>(elem))
                .ToListAsync());
        }

        // POST api/values
        [HttpPost("new")]
        public async Task<ActionResult> Post([FromBody] ImageUploadDto dto)
        {
            if (!_authService.CheckIfUserIsAuthorized(dto.OwnerId))
            {
                return Unauthorized("Cannot create image on behalf of someone else");
            }

            var imageEntity = _mapper.Map<ImagehubImage>(dto);

            await _service.CreateAsync(imageEntity);

            return Accepted(new
            {
                imageEntity.FileName,
                imageEntity.Id,
                imageEntity.OwnerId
            });
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ImageDto imageDto)
        {

            if (!_authService.CheckIfUserIsAuthorized(imageDto.ImageOwnerId))
            {
                return Unauthorized("Cannot modify image on behalf of someone else");
            }

            var imageEntity = _mapper.Map<ImagehubImage>(imageDto);
            await _service.UpdateAsync(imageEntity);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, UserDto user)
        {
            if (!_authService.CheckIfUserIsAuthorized(user.Id))
            {
                return Unauthorized("Cannot delete image on behalf of someone else");
            }

            var imageInDb = await _service.GetElementAsync(id);
            if(imageInDb == null)
            {
                return NotFound(id);
            }
            else
            {
                await _service.DeleteAsync(imageInDb);
                return Ok(id);
            }
        }
    }
}
