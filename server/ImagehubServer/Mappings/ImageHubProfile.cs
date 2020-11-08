using AutoMapper;
using Data;
using Data.Models;
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
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.FileName))
                .ForMember(dest => dest.OwnerId, m => m.MapFrom(src => src.OwnerId))
                .ReverseMap();

            CreateMap<ImagehubImage, ImageUploadDto>()
                .ForMember(dest => dest.Base64EncodedImage, m => m.MapFrom(src => src.Base64EncodedImage))
                .ForMember(dest => dest.ImageNameWithExtension, m => m.MapFrom(src => src.FileName))
                .ForMember(dest => dest.OwnerId, m => m.MapFrom(src => src.OwnerId))
                .ReverseMap();

            CreateMap<FriendRequest, Friend>()
            .ForMember(dest => dest.Left, m => m.MapFrom(src => src.From))
            .ForMember(dest => dest.Right, m => m.MapFrom(src => src.To))
            .ForMember(dest => dest.LeftId, m => m.MapFrom(src => src.ToId))
            .ForMember(dest => dest.RightId, m => m.MapFrom(src => src.FromId))
            .ForMember(dest => dest.Id, m => m.Ignore())
            .ReverseMap();

            //CreateMap<UserDto, ImageHubUser>()
            //  .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
            //  .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.Username))
            //  .ReverseMap();

            CreateMap<FriendRequest, FriendRequestDto>()
              .ForMember(dest => dest.FromId, m => m.MapFrom(src => src.FromId))
              .ForMember(dest => dest.ToId, m => m.MapFrom(src => src.ToId))
              .ReverseMap();

            CreateMap<Friend, UnfriendDto>()
              .ForMember(dest => dest.FromId, m => m.MapFrom(src => src.LeftId))
              .ForMember(dest => dest.ToId, m => m.MapFrom(src => src.RightId))
              .ReverseMap();

            CreateMap<ImagehubImage, ImageDto>()
              .ForMember(dest => dest.Base64EncodedImage, m => m.MapFrom(src => src.Base64EncodedImage))
              .ForMember(dest => dest.FileName, m => m.MapFrom(src => src.FileName))
              .ForMember(dest => dest.ImageId, m => m.MapFrom(src => src.Id))
              .ForMember(dest => dest.ImageOwnerId, m => m.MapFrom(src => src.OwnerId))
              .ReverseMap();
        }
    }
}
