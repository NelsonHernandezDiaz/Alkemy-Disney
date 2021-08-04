using AutoMapper;
using Disney.Application.Commands;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;

namespace Disney.Application.AutoMappers
{
    public class mapUser : Profile
    {
        public mapUser()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterUser, User>().ReverseMap();
        }
    }
}
