using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        #region Context and Constructor
        private readonly DataContext context;
        public GenreRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion

        public async Task<IQueryable<Genre>> GetAllGenres()
        {
            var result = await context.Genres
                .Where(x => x.Status == false)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return (IQueryable<Genre>)result;
        }  
        public async Task CreateGenre(Genre entity)
        {
            await context.Genres.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateGenre(Genre entity)
        {
            context.Genres.Update(entity);
            await context.SaveChangesAsync();
        }
        public Genre GetGenreByName(string name)
        {
            return context.Genres
                .Where(x => x.Status == false && x.Name == name).FirstOrDefault();
        }
        public bool GenreExists(string name)
        {
            return context.Genres.Any(x => x.Name == name);
        }
    }
}
