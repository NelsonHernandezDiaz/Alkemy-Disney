using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDTO>> GetAllCharacters();
        CharacterDTO GetCharacterByName(string name);
        CharacterDTO GetCharacterByAge(int age);
        Task<IEnumerable<CharacterDTO>> GetCharacterByMovieSerie(string movieserie);
        Result CreateCharacter(CharacterDTO request);
        Result UpdateCharacter(CharacterDTO request);
        Result DeleteCharacter(CharacterDTO request);
    }
}
