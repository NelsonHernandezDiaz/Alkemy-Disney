using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class MovieSerieRepository : IMovieSerieRepository
    {
        #region Context and Constructor
        private readonly DataContext context;
        public MovieSerieRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion

        public async Task<IQueryable<MovieSerie>> GetAllMoviesSeries()
        {
            var result = await context.MoviesSeries
                .Where(x => x.Status == false)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return (IQueryable<MovieSerie>)result;
        }
        public MovieSerie GetMovieSerieByName(string name)
        {
            return context.MoviesSeries.Where(x => x.Status == true &&
                                                   x.Name == name).FirstOrDefault();
        }
        public async Task<IQueryable<MovieSerie>> GetMovieSerieByGenre(string genre)
        {
            var result = await context.Genres
                .Where(x => x.Name == genre)
                .Include(x => x.associatedMovieSerie)
                             .OrderBy(x => x.associatedMovieSerie.Name)
                             .ToListAsync();
            return (IQueryable<MovieSerie>)result;
        }
        public async Task<IQueryable<MovieSerie>> GetMovieSerieByOrder()
        {
            var result = await context.MoviesSeries
                .Where(x => x.Status == false)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return (IQueryable<MovieSerie>)result;
        }
        public async Task CreateMovieSerie(MovieSerie entity)
        {
            await context.MoviesSeries.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateMovieSerie(MovieSerie entity)
        {
            context.MoviesSeries.Update(entity);
            await context.SaveChangesAsync();
        }        
        public bool MovieSerieExists(string name)
        {
            return context.MoviesSeries.Any(x => x.Name == name);
        }
    }
}
