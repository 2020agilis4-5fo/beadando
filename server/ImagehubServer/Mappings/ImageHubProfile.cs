using AutoMapper;
using Data;
using Imagehub.Core.Dto;

namespace Imagehub.Core.Mappings
{
    public class ImageHubProfile : Profile
    {
        public ImageHubProfile()
        {
            CreateMap<ImagehubImage, ImageResponseDto>()
                .ForMember(dest => dest.Base64EncodedImage, m => m.MapFrom(src => src.Base64EncodedImage))
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.FileName));
        }
    }
}
