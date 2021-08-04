using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;

namespace Disney.Application.AutoMappers
{
    public class mapGenre : Profile
    {
        public mapGenre()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
