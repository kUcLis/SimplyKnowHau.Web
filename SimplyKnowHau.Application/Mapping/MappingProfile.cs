using AutoMapper;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Domain.Entities;

namespace SimplyKnowHau.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
