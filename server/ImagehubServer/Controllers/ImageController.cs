using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Imagehub.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ImagehubServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task Post([FromBody] ImageUploadDto dto)
        {
            var imageEntity = _mapper.Map<ImagehubImage>(dto);
            await _service.CreateAsync(imageEntity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
