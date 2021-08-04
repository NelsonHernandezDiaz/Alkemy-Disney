using Disney.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Interfaces
{
    public interface IGenreRepository
    {
        Task<IQueryable<Genre>> GetAllGenres();
        Task CreateGenre(Genre entity);
        Task UpdateGenre(Genre entity);
        Genre GetGenreByName(string name);
        bool GenreExists(string name);
    }
}
