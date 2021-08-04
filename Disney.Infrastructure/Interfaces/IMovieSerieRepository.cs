using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Interfaces
{
    public interface IMovieSerieRepository
    {
        Task<IQueryable<MovieSerie>> GetAllMoviesSeries();
        MovieSerie GetMovieSerieByName(string name);
        Task<IQueryable<MovieSerie>> GetMovieSerieByGenre(string genre);
        Task<IQueryable<MovieSerie>> GetMovieSerieByOrder();
        Task CreateMovieSerie(MovieSerie entity);
        Task UpdateMovieSerie(MovieSerie entity);
        bool MovieSerieExists(string name);        
    }
}
