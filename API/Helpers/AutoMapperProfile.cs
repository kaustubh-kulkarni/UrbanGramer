using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Post, PostDto>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}