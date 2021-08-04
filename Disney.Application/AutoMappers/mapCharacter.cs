using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;

namespace Disney.Application.AutoMappers
{
    public class mapCharacter : Profile
    {
        public mapCharacter()
        {
            CreateMap<Character, CharacterDTO>().ReverseMap();
        }
    }
}
