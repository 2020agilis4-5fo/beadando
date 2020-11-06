using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Models;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ImagehubServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("img")]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageService _service;

        public ImageController(IMapper mapper, IImageService service)
        {
            _mapper = mapper;
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ImageResponseDto>> Get()
        {
            return (await _service.GetElementsAsync())
                .Select(elem => _mapper.Map<ImageResponseDto>(elem));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ImageResponseDto> Get(int id)
        {
            var element = await _service.GetElementAsync(id);
            return _mapper.Map<ImageResponseDto>(element);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ImageUploadDto dto)
        {
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
            // todo: check ownership?
            var imageEntity = _mapper.Map<ImagehubImage>(imageDto);
            await _service.UpdateAsync(imageEntity);
            return Ok(new ImageResponseDto()
            {
                Name = imageEntity.FileName
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
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
