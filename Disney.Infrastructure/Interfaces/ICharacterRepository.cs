using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IQueryable<Character>> GetAllCharacters();
        Character GetCharacterByName(string name);
        Character GetCharacterByAge(int age);
        Task<IQueryable<Character>> GetCharacterByMovieSerie(string movieserie);
        Task CreateCharacter(Character entity);
        Task UpdateCharacter(Character entity);
        bool CharacterExists(string name);
    }
}
