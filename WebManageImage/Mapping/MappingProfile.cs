

using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace WebManageImage.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Image, GetImageDto>();
            CreateMap<ImageForCreateDto, Image>();
            CreateMap<ImageForUpdateDto, Image>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<Like, LikeDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentForCreateDto, Comment>();
            CreateMap<User, UserDto>();



        }
    }
}
