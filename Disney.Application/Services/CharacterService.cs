using AutoMapper;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class CharacterService : ICharacterService
    {
        #region Obj and Constructor
        private readonly IMapper mapper;
        private readonly ICharacterRepository IcharacterRepository;
        public CharacterService(IMapper mapper, ICharacterRepository IcharacterRepository)
        {
            this.IcharacterRepository = IcharacterRepository;
            this.mapper = mapper;
        }
        #endregion

        public async Task<IEnumerable<CharacterDTO>> GetAllCharacters()
        {
            var result = await IcharacterRepository.GetAllCharacters();
            var response =mapper.Map<IEnumerable<CharacterDTO>>(result);

            return response;
        }
        public CharacterDTO GetCharacterByName(string name)
        {
            var entity = IcharacterRepository.GetCharacterByName(name);
            var response = mapper.Map<CharacterDTO>(entity);

            return response;
        }
        public CharacterDTO GetCharacterByAge(int age)
        {
            var entity = IcharacterRepository.GetCharacterByAge(age);
            var response = mapper.Map<CharacterDTO>(entity);

            return response;
        }
        public async Task<IEnumerable<CharacterDTO>> GetCharacterByMovieSerie(string movieserie)
        {
            var result = await IcharacterRepository.GetCharacterByMovieSerie(movieserie);
            var response = mapper.Map<IEnumerable<CharacterDTO>>(result);

            return response;
        }
        public Result CreateCharacter(CharacterDTO request)
        {
            bool exists = IcharacterRepository.CharacterExists(request.Name);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Character");

            var entity = mapper.Map<Character>(request);

            IcharacterRepository.CreateCharacter(entity);
            return new Result().Success($"Se ha agregado correctamente el Character {entity.Name} al sistema");
        }        
        public Result UpdateCharacter(CharacterDTO request)
        {
            var update = IcharacterRepository.CharacterExists(request.Name);
            if (update == null)
                return new Result().NotFound();

            var entity = mapper.Map<Character>(request);

            IcharacterRepository.UpdateCharacter(entity);
            return new Result().Success($"Se han aplicado los cambios correctamente al Character {entity.Name}");
        }
        public Result DeleteCharacter(CharacterDTO request)
        {
            Character delete = IcharacterRepository.GetCharacterByName(request.Name);
            if (delete == null)
                return new Result().NotFound();

            delete.Status = true;
            var entity = mapper.Map<Character>(delete);

            IcharacterRepository.UpdateCharacter(entity);
            return new Result().Success($"Se eliminó el Character {entity.Name}");
        }
    }
}
