using AutoMapper;
using Nettium_Test.Application.DTOs.Users;
using Nettium_Test.Domain.Entities;

namespace Nettium_Test.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
