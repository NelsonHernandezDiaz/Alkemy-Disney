using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        #region Context and Constructor
        private readonly DataContext context;
        public CharacterRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion

        public async Task<IQueryable<Character>> GetAllCharacters()
        {
            var result = await context.Characters
                .Where(x => x.Status == false)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return (IQueryable<Character>)result;
        }        
        public Character GetCharacterByName(string name)
        {
            return context.Characters
                .Where(x => x.Status == false && x.Name == name).FirstOrDefault();
        }
        public Character GetCharacterByAge(int age)
        {
            return context.Characters
                .Where(x => x.Status == false && x.Age == age).FirstOrDefault();
        }
        public async Task<IQueryable<Character>> GetCharacterByMovieSerie(string movieserie)
        {
            var result = await context.MoviesSeries
                .Where(x => x.Name == movieserie)
                .Include(x => x.associatedCharacter)
                             .OrderBy(x => x.associatedCharacter.Name)
                             .ToListAsync();
            return (IQueryable<Character>)result;
        }
        public async Task CreateCharacter(Character entity)
        {
            await context.Characters.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCharacter(Character entity)
        {
            context.Characters.Update(entity);
            await context.SaveChangesAsync();
        }
        public bool CharacterExists(string name)
        {
            return context.Characters.Any(x => x.Name == name);
        }        
    }
}
